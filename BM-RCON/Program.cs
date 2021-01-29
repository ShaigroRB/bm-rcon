using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using BM_RCON.BM_RCON_lib;


namespace BM_RCON
{
    class Program
    {
        // change default parameters if needed
        const int port = 42070;
        const string addr = "127.0.0.1";
        const string passwd = "admin";

        private static void sendRequest(RCON_Client rcon, RequestType requestType, string body)
        {
            Thread.Sleep(160);
            rcon.SendRequest(requestType, body);
            Console.WriteLine("");
        }

        static int Main()
        {            
            // use a ConsoleLogger as our logger
            ILogger logger = new ConsoleLogger();
            try
            {
                /*
                 * Example on how to use the BM rcon lib
                 * The program reads from the chat.
                 * If in the chat is written "!bigtext Hello",
                 * it will call the "eventtext" command with "Hello" as string in red.
                 * If a player taunts, the program will stops.
                */
                string body = passwd;
                string bigtext_cmd = "!bigtext";

                // init rcon object with address, port, password and logger
                RCON_Client rcon_obj = new RCON_Client(addr, port, body, logger);
                // connect the rcon client to addr:port with body
                rcon_obj.Connect();
                logger.Log("");

                // enable mutators on server if not enabled
                sendRequest(rcon_obj, RequestType.command, "enablemutators");

                RCON_Event evt;
                while (true)
                {
                    // receive the latest event
                    evt = rcon_obj.ReceiveEvent();
                    logger.Log("");

                    // check if somebody type something in the chat
                    if (evt.EventID == (short)EventType.chat_message)
                    {
                        // get the message
                        string msg = evt.JsonAsObj.Message.ToString();

                        // check if "!bigtext" is in the message
                        int index = msg.IndexOf(bigtext_cmd);
                        if (index != -1)
                        {
                            // get the text to display
                            string bigtext = msg.Substring(index + bigtext_cmd.Length);
                            // send a request which is the command "eventtext" with its parameters
                            sendRequest(rcon_obj, RequestType.command, $"eventtext \"{bigtext}\" \"255\"");
                        }
                    }

                    // if the server ping the rcon client,
                    // ping it back to keep the connection alive
                    if (evt.EventID == (short)EventType.rcon_ping)
                    {
                        sendRequest(rcon_obj, RequestType.ping, "I pinged");
                    }
                    // if a player taunts, stop the loop
                    if (evt.EventID == (short)EventType.player_taunt)
                    {
                        break;
                    }
                }

                // avoid sending to oblivion the last request made
                Thread.Sleep(160);

                // disconnect the rcon client
                rcon_obj.Disconnect();
            }
            // if something goes wrong, you will end up here
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                logger.LogError("Something went wrong in the main.");
            }

            // press 'Enter' to exit the console
            Console.Read();
            return 0;
        }
    }
}
