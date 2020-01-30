using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using lib = BM_RCON.BM_RCON_lib;

namespace BM_RCON.mods.betmode
{
    class Betmode
    {
        const int port = 42070;
        const string addr = "127.0.0.1";
        const string passwd = "admin";

        private static void sendRequest(lib.BM_RCON rcon, RequestType requestType, string body)
        {
            Thread.Sleep(160);
            rcon.SendRequest(requestType, body);
            Console.WriteLine("");
        }

        private static lib.RCON_Event receiveEvt(lib.BM_RCON rcon)
        {
            lib.RCON_Event evt = rcon.ReceiveEvent();
            Console.WriteLine("");
            return evt;
        }
        static int Main(string[] args)
        {

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Something went wrong in the main.");
            }

            return 0;
        }
    }
}
