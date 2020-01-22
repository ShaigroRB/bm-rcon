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
    }
}
