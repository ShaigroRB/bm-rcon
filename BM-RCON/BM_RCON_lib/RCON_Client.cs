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
            this.address = addr;
            this.port = port;
            this.password = password;
            this.logger = logger;

            UTF8Encoding uTF8 = new UTF8Encoding();
            this.start_del_bytes = uTF8.GetBytes("┐");
        }

        /// <summary>
        /// Try to connect the RCON client to the server
        /// </summary>
        /// <returns>Returns 0 if successfully connected, otherwise returns 1</returns>
        public int Connect()
        {
            int status;
            try
            {
                logger.LogInfo($"Connecting to {address}:{port} using '{password}' as password...");

                // no method to reconnect, let's instanciate one each time...
                this.client = new TcpClient(this.address, this.port);

                NetworkStream stream = this.client.GetStream();
                stream.WriteTimeout = 7000;

                status = SendRequest(RequestType.login, this.password);
                if (status == 1)
                {
                    logger.LogWarning("Failed to connect.");
                }
                else
                {
                    logger.LogInfo("Connection successful.");
                }
            }
            catch (Exception e)
            {
                logger.LogError("Failed to connect.");
                logger.LogError($"Error: {e.ToString()}");
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// Disconnect the RCON client from the server
        /// </summary>
        public void Disconnect()
        {
            this.client.Close();
            logger.LogInfo($"Client {address}:{port} disconnected.");
        }

        /// <summary>
        /// Create packet composed of bytes
        /// </summary>
        /// <param name="RequestType">Type of the request (see enum RequestType)</param>
        /// <param name="body">Body of the request</param>
        /// <returns>Returns the packet</returns>
        public byte[] CreatePacket(RequestType RequestType, string body)
        {
            /*
             * final_packet is a concatenation of:
             * - a short (16-bit integer) corresponding to the request's type
             * - a string corresponding to the parameters specific for each request type
            */

            // reqType needs to be an 16-bit integer
            short req_type = (short)RequestType;
            UTF8Encoding uTF8 = new UTF8Encoding();

            // convert into bytes
            byte[] req_type_bytes = BitConverter.GetBytes(req_type);
            byte[] body_bytes = uTF8.GetBytes(body);

            // final packet
            // + 1 at the end to add a null byte
            byte[] final_packet = new byte[req_type_bytes.Length + body_bytes.Length + 1];

            int byte_ptr = 0;

            // copy bytes to final packet
            req_type_bytes.CopyTo(final_packet, byte_ptr);
            byte_ptr += req_type_bytes.Length;

            body_bytes.CopyTo(final_packet, byte_ptr);
            byte_ptr += body_bytes.Length;

            // don't forget the last null byte
            final_packet[byte_ptr] = (byte)0;

            return final_packet;
        }

        /// <summary>
        /// Parse a packet (array of bytes) and returns a RCON_Event object
        /// </summary>
        /// <param name="pckt_bytes">Packet as bytes</param>
        /// <returns>Returns a RCON_Event object</returns>
        public RCON_Event ParsePacket(byte[] pckt_bytes)
        {
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

            // convert bytes to short
            short json_size = BitConverter.ToInt16(pckt_bytes, byte_ptr);
            byte_ptr += short_bytes;
            short eventID = BitConverter.ToInt16(pckt_bytes, byte_ptr);
            byte_ptr += short_bytes;

            // get json as string from bytes and remove the end delimiter
            string pckt_json = uTF8.GetString(pckt_bytes, byte_ptr, json_size).TrimEnd('└');

            RCON_Event rcon_event = new RCON_Event(json_size, eventID, pckt_json, logger);

            return rcon_event;
        }

        /// <summary>
        /// Send a request to the server given a packet (bytes)
        /// </summary>
        /// <param name="req">The packet (request)</param>
        /// <returns>Returns 0 if the request was successfully sent, otherwise returns 1</returns>
        public int SendRequest(byte[] req)
        {
            int status = 0;
            try
            {
                NetworkStream stream = this.client.GetStream();
                stream.WriteTimeout = 7000;
                stream.Write(req, 0, req.Length);

                logger.LogDebug($"Request ({Encoding.UTF8.GetString(req)}) sent.");
            }
            catch (Exception e)
            {
                logger.LogError("Failed to send a request.");
                logger.LogError($"Error: {e.ToString()}");
                status = 1;
            }
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
            byte[] pckt = CreatePacket(req_type, body);
            int status = SendRequest(pckt);
            if (status == 1)
            {
                logger.LogWarning($"Failed to send request of type {req_type.ToString()} and of body {body}");
            }
            return status;
        }

        /// <summary>
        /// Receive the next event from the server
        /// </summary>
        /// <returns>Returns a RCON_Event if successfully received the next event, otherwise returns null</returns>
        public RCON_Event ReceiveEvent()
        {
            RCON_Event rcon_evt = null;
            try
            {
                // always get stream, and do not close it afterwards
                NetworkStream stream = this.client.GetStream();
                stream.ReadTimeout = 7000;

                byte[] packet_received = new byte[this.client.ReceiveBufferSize];
                if (this.client.ReceiveBufferSize > 0)
                {
                    // reads data from stream and put it in the buffer "packet_received"
                    stream.Read(packet_received, 0, packet_received.Length);

                    rcon_evt = ParsePacket(packet_received);

                    logger.LogDebug($"Event ({rcon_evt.EventID}) received.");
                }
            }
            catch (Exception e)
            {
                logger.LogError("Failed to receive event.");
                logger.LogError($"Error: {e.ToString()}");
            }

            return rcon_evt;
        }
    }
}
