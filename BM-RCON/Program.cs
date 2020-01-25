using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// alias for namespace
using lib = BM_RCON.BM_RCON_lib;
using RequestType = BM_RCON.BM_RCON_lib.RequestType;


namespace BM_RCON
{
    class Program
    {
        // change default parameters if needed
        const int port = 42070;
        const string addr = "127.0.0.1";
        const string passwd = "admin";

        private static void sendRequest(lib.BM_RCON rcon, RequestType requestType, string body)
        {
            Thread.Sleep(160);
            rcon.SendRequest(requestType, body);
        }

        static int Main(string[] args)
        {
            try
            {                
                string body = passwd;
                // init rcon object
                lib.BM_RCON rcon_obj = new lib.BM_RCON(addr, port, body);
                rcon_obj.Connect();
                Console.WriteLine("");

                //sendRequest(rcon_obj, RequestType.command, "enablemutators");
                lib.RCON_Event evt;
                while (true)
                {
                    evt = rcon_obj.ReceiveEvent();
                    Console.WriteLine("");

                    if (evt.EventID == (short)lib.EventType.player_spawn)
                    {
                        Console.WriteLine("Event ID: {0}", evt.EventID.ToString());
                        Console.WriteLine("JSON:");
                        dynamic obj = evt.JsonAsObj;
                        Console.WriteLine("First weapon id: {0}", obj.Weap1.ToString());
                        Console.WriteLine("Secondary weapon id: {0}", obj.Weap2.ToString());
                        Console.WriteLine("Grenade slot id: {0}", obj.Equip.ToString());

                        Console.WriteLine("");
                        Console.WriteLine(evt.JsonAsObj.ToString());
                    }

                    if (evt.EventID == (short)lib.EventType.rcon_ping)
                    {
                        sendRequest(rcon_obj, RequestType.ping, "I pinged");
                    }
                    if (evt.EventID == (short)lib.EventType.player_taunt)
                    {
                        break;
                    }
                }

                Thread.Sleep(160); // last request before disconnecting

                rcon_obj.Disconnect();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Hello there!");
            }

            Console.Read();
            return 0;
        }
    }
}
