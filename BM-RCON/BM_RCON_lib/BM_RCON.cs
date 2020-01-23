using System;
using System.Text;
using System.Net.Sockets;

namespace BM_RCON.BM_RCON_lib
{
    class BM_RCON
    {
        string address;
        int port;
        string password;
        TcpClient client;

        // delimiters
        byte[] start_del_bytes;
        byte[] end_del_bytes;

        public BM_RCON(string addr, int port, string password)
        {
            this.address = addr;
            this.port = port;
            this.password = password;
            this.client = new TcpClient(addr, port);
            
            UTF8Encoding uTF8 = new UTF8Encoding();
            this.start_del_bytes = uTF8.GetBytes("┐");
            this.end_del_bytes = uTF8.GetBytes("└");
        }

        public int Connect()
        {
            int status = 0;
            NetworkStream stream = client.GetStream();
            try
            {
                Console.WriteLine("Connecting to {0}:{1} using '{2}' as password...",
                                    address, port, password);
                // initialize client
                stream.ReadTimeout = 4000;

                byte[] packet_connection = CreatePacket(RequestType.login, password);

                // send request
                stream.Write(packet_connection, 0, packet_connection.Length);
                Console.WriteLine("Connection successful.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect.");
                Console.WriteLine("Error: {0}", e.ToString());
                status = 1;
            }
            stream.Close();
            return status;
        }

        public void Disconnect()
        {
            client.Close();
        }

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

        public string ParsePacket(byte[] pckt_bytes)
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
            int byte_ptr = start_del_bytes.Length;

            // number of bytes for 16-bit integer
            int short_bytes = 2;

            byte[] json_size_bytes = new byte[short_bytes];
            byte[] eventID_bytes = new byte[short_bytes];

            // get the bytes for json size
            Array.Copy(pckt_bytes, byte_ptr, json_size_bytes, 0, short_bytes);
            byte_ptr += short_bytes;

            // get the bytes for eventID
            Array.Copy(pckt_bytes, byte_ptr, eventID_bytes, 0, short_bytes);
            byte_ptr += short_bytes;

            // convert bytes to short
            short json_size = BitConverter.ToInt16(json_size_bytes, 0);
            short eventID = BitConverter.ToInt16(eventID_bytes, 0);


            Console.WriteLine("JSON size: {0}", json_size.ToString());
            Console.WriteLine("Event ID: {0}", eventID.ToString());

            string pckt_string = "";
            return pckt_string;
        }
    }
}
