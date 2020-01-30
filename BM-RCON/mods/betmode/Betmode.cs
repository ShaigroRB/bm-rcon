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
            /*
             * - you bet the minimum *number of people who will survive through the next wave without dying
             * - the next wave will spawn the same amount of bosses than the *number bet
             * - if the bet is won, every player will earn a *number of random vices
            */
             /*
              * the events to catch are:
              * - player_connect:
              *     - Check if an instance of Player corresponding to the player exists
              *     - If not, create one and add it to connected_players
              *     - Otherwise, move the corresponding Player from disconnected_players to connected_players
              * - player_disconnect:
              *     - Set the Player as dead
              *     - Update the Bet (if one) with the Player
              *     - Move the Player from connected_players to disconnected_players
              * - player_spawn:
              *     - Set the Player as alive
              * - player_death:
              *     - Set the Player as dead
              *     - Update the Bet (if one) with the Player
              * - survival_get_vice:
              * - survival_use_vice:
              * - survival_new_wave
              * - survival_flag_unlocked
              * - chat_message
              * 
             */
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
