using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace BM_RCON.BM_RCON_lib
{
    class BM_RCON
    {
        string address;
        int port;
        string password;
        TcpClient client;

        public BM_RCON(string addr, int port, string password)
        {
            this.address = addr;
            this.port = port;
            this.password = password;
            this.client = new TcpClient(addr, port);
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

        public byte[] CreatePacket(RequestType RequestType, string body)
        {
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
    }
}
