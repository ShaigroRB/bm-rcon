using System;
using System.Text;
using System.Net.Sockets;

namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// RCON client for Boring Man v2
    /// </summary>
    class RCON_Client
    {
        readonly string address;
        readonly int port;
        readonly string password;
        private readonly ILogger logger;

        // One client to rule them all
        TcpClient client;

        // delimiters
        readonly byte[] start_del_bytes;

        /// <summary>
        /// RCON client for Boring Man v2
        /// </summary>
        /// <param name="addr">IP Address of the server</param>
        /// <param name="port">RCON port of the server</param>
        /// <param name="password">RCON password of the server</param>
        /// <param name="logger">The logger used</param>
        public RCON_Client(string addr, int port, string password, ILogger logger)
        {
            logger.Trace($"A client connecting to {addr}:{port} is instanciating.");
            this.address = addr;
            this.port = port;
            this.password = password;
            this.logger = logger;

            UTF8Encoding uTF8 = new UTF8Encoding();
            this.start_del_bytes = uTF8.GetBytes("┐");
            logger.Trace("Finished instanciating the client.");
        }

        /// <summary>
        /// Try to connect the RCON client to the server
        /// </summary>
        /// <returns>Returns 0 if successfully connected, otherwise returns 1</returns>
        public int Connect()
        {
            logger.Trace("RCON_Client.Connect() starts.");
            int status;
            try
            {
                logger.Info($"Connecting to {address}:{port} using '{password[0]}..' as password...");

                logger.Debug($"Creating a client for {address}:{port}");
                // no method to reconnect, let's instanciate one each time...
                this.client = new TcpClient(this.address, this.port);

                logger.Trace("Getting stream from the client.");
                NetworkStream stream = this.client.GetStream();
                logger.Trace("Setting timeout of stream's writing to 7000ms.");
                stream.WriteTimeout = 7000;

                logger.Trace($"Send request to login with '{password[0]}..' as password");
                status = SendRequest(RequestType.login, this.password);
                if (status == 1)
                {
                    logger.Error("Failed to connect.");
                }
                else
                {
                    logger.Info("Connection successful.");
                }
            }
            catch (Exception e)
            {
                logger.Fatal("Failed to connect.");
                logger.Debug($"Error: {e.ToString()}");
                status = 1;
            }
            logger.Trace("RCON_Client.Connect() finishes.");
            return status;
        }

        /// <summary>
        /// Disconnect the RCON client from the server
        /// </summary>
        public void Disconnect()
        {
            logger.Trace("RCON_Client.Disconnect() starts.");
            logger.Debug($"Closing the client opened on {address}:{port}");
            this.client.Close();
            logger.Info($"Client on {address}:{port} disconnected.");
            logger.Trace("RCON_Client.Disconnect() finishes.");
        }

        /// <summary>
        /// Create packet composed of bytes
        /// </summary>
        /// <param name="RequestType">Type of the request (see enum RequestType)</param>
        /// <param name="body">Body of the request</param>
        /// <returns>Returns the packet</returns>
        public byte[] CreatePacket(RequestType RequestType, string body)
        {
            logger.Trace("RCON_Client.CreatePacket(type, body) starts.");
            /*
             * final_packet is a concatenation of:
             * - a short (16-bit integer) corresponding to the request's type
             * - a string corresponding to the parameters specific for each request type
            */

            // reqType needs to be an 16-bit integer
            short req_type = (short)RequestType;
            UTF8Encoding uTF8 = new UTF8Encoding();

            // convert into bytes
            logger.Trace("Converting the request type to bytes.");
            byte[] req_type_bytes = BitConverter.GetBytes(req_type);
            logger.Trace("Converting the body to bytes.");
            byte[] body_bytes = uTF8.GetBytes(body);

            // final packet
            // + 1 at the end to add a null byte
            logger.Trace("Creating the final packet.");
            byte[] final_packet = new byte[req_type_bytes.Length + body_bytes.Length + 1];

            int byte_ptr = 0;

            // copy bytes to final packet
            logger.Trace("Copying the request type to the final packet.");
            req_type_bytes.CopyTo(final_packet, byte_ptr);
            byte_ptr += req_type_bytes.Length;

            logger.Trace("Copying the body to the final packet.");
            body_bytes.CopyTo(final_packet, byte_ptr);
            byte_ptr += body_bytes.Length;

            // don't forget the last null byte
            final_packet[byte_ptr] = (byte)0;

            logger.Trace("RCON_Client.CreatePacket(type, body) finishes.");
            return final_packet;
        }

        /// <summary>
        /// Parse a packet (array of bytes) and returns a RCON_Event object
        /// </summary>
        /// <param name="pckt_bytes">Packet as bytes</param>
        /// <returns>Returns a RCON_Event object</returns>
        public RCON_Event ParsePacket(byte[] pckt_bytes)
        {
            logger.Trace("RCON_Client.ParsePacket(bytes) starts.");
            /*
             * pckt_bytes is a concatenation of:
             * - the start delimiter "┐"
             * - a short (16-bit integer) corresponding to the size of the JSON
             * - a short (16-bit integer) corresponding to eventID of the RCON event
             * - the JSON
             * - the end delimiter "└"
            */

            UTF8Encoding uTF8 = new UTF8Encoding();

            // skip the start delimiter
            int byte_ptr = this.start_del_bytes.Length;

            // number of bytes for 16-bit integer
            int short_bytes = 2;

            logger.Trace("Getting JSON size from the packet as bytes.");
            // convert bytes to short
            short json_size = BitConverter.ToInt16(pckt_bytes, byte_ptr);
            byte_ptr += short_bytes;
            logger.Trace("Getting event ID from the packet as bytes.");
            short eventID = BitConverter.ToInt16(pckt_bytes, byte_ptr);
            byte_ptr += short_bytes;

            logger.Trace("Get the JSON from the packet as bytes.");
            // get json as string from bytes and remove the end delimiter
            string pckt_json = uTF8.GetString(pckt_bytes, byte_ptr, json_size).TrimEnd('└');

            logger.Trace($"Creating an event.");
            RCON_Event rcon_event = new RCON_Event(json_size, eventID, pckt_json, logger);

            logger.Trace("RCON_Client.ParsePacket(bytes) finishes.");
            return rcon_event;
        }

        /// <summary>
        /// Send a request to the server given a packet (bytes)
        /// </summary>
        /// <param name="req">The packet (request)</param>
        /// <returns>Returns 0 if the request was successfully sent, otherwise returns 1</returns>
        public int SendRequest(byte[] req)
        {
            logger.Trace("RCON_Client.SendRequest(bytes) starts.");
            int status = 0;
            try
            {
                logger.Trace("Getting stream from the client.");
                NetworkStream stream = this.client.GetStream();
                logger.Trace("Setting timeout of stream's writing to 7000ms.");
                stream.WriteTimeout = 7000;
                logger.Trace("Writing on the stream.");
                stream.Write(req, 0, req.Length);

                logger.Trace($"Writing on the stream successful.");
            }
            catch (Exception e)
            {
                logger.Error("Failed to send a request.");
                logger.Debug($"Error: {e.ToString()}");
                status = 1;
            }
            logger.Trace("RCON_Client.SendRequest(bytes) finishes.");
            return status;
        }

        /// <summary>
        /// Send a request to the server given a request type and a body
        /// </summary>
        /// <param name="req_type">The type of the request</param>
        /// <param name="body">The body of the request</param>
        /// <returns>Returns 0 if the request was successfully sent, otherwise returns 1</returns>
        public int SendRequest(RequestType req_type, string body)
        {
            logger.Trace("RCON_Client.SendRequest(type, body) starts.");
            logger.Trace($"Creating packet of type: {req_type.ToString()}, body: {body}");
            byte[] pckt = CreatePacket(req_type, body);

            logger.Trace("Packet created.");
            logger.Trace("Sending request.");
            int status = SendRequest(pckt);

            logger.Trace("Checking if the request was successfully sent to the server.");
            if (status == 1)
            {
                logger.Error($"Failed to send request of type {req_type.ToString()} and of body {body}");
            }
            else
            {
                logger.Debug($"Request of type: {req_type.ToString()}, body: '{body}' sent to the server.");
            }
            logger.Trace("RCON_Client.SendRequest(type, body) finishes.");
            return status;
        }

        /// <summary>
        /// Receive the next event from the server
        /// </summary>
        /// <returns>Returns a RCON_Event if successfully received the next event, otherwise returns null</returns>
        public RCON_Event ReceiveEvent()
        {
            logger.Trace("RCON_Client.ReceiveEvent() starts.");
            RCON_Event rcon_evt = null;
            try
            {
                logger.Trace("Getting stream from the client.");
                // always get stream, and do not close it afterwards
                NetworkStream stream = this.client.GetStream();
                logger.Trace("Setting timeout of stream's reading to 7000ms.");
                stream.ReadTimeout = 7000;

                byte[] packet_received = new byte[this.client.ReceiveBufferSize];
                if (this.client.ReceiveBufferSize > 0)
                {
                    logger.Trace("Reading data from the stream.");
                    // reads data from stream and put it in the buffer "packet_received"
                    stream.Read(packet_received, 0, packet_received.Length);

                    logger.Trace("Parsing the data received and create a new event from it.");
                    rcon_evt = ParsePacket(packet_received);

                    logger.Debug($"Event {(EventType)rcon_evt.EventID} ({rcon_evt.EventID}) received.");
                }
                logger.Trace("Finished checking for data in the stream");
            }
            catch (Exception e)
            {
                logger.Error("Failed to receive event.");
                logger.Debug($"Error: {e.ToString()}");
            }

            logger.Trace("RCON_Client.ReceiveEvent() finishes.");
            return rcon_evt;
        }
    }
}
