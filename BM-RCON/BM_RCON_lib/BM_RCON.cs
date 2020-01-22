using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.BM_RCON_lib
{
    class BM_RCON
    {
        string address;
        int port;
        string password;

        public BM_RCON(string addr, int port, string password)
        {
            this.address = addr;
            this.port = port;
            this.password = password;
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
