﻿using System;
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
              *     - Get profile and new vice
              *     - Search for the Player with the corresponding profile
              *     - Update its vices with the new vice
              * - survival_use_vice:
              *     - Get profile and vice used
              *     - Search for the Player with the corresponding profile
              *     - Update its vices with vice used
              * - survival_new_wave:
              *     - Stop checking for vote in chat for next Bet
              *     - Set Vote of all connected_players to NOTHING
              *     - Set Players in Bet with connected_players
              *     - Decide if next Bet is accepted or not depending on Vote of Players
              *     - If accepted, set is_bet_flag_unlocked to true
              *     - If not accepted, set is_bet_flag_unlocked to false and set next Bet to null
              *     - Check if current Bet is won
              *     - If yes, for each Player in connected_players:
              *         - Get the vices from Bet
              *         - Update the Player's vices
              *         - Send request to update the player's vices
              *     - Replace current Bet by next Bet
              * - survival_flag_unlocked:
              *     - Check is_bet_flag_unlocked
              *     - If true, for each enemies in Bet:
              *         - Send request to spawn the enemy
              * - chat_message:
              *     - Check if next Bet exists
              *     - If yes, check if !vote <yes/no> has been written:
              *         - Get profile from Player
              *         - For the Player in connected_players with the same profile, set its Vote
              *         - Check if Players in connected_players all have a Vote to either YES or NO
              *         - If yes, check if next Bet is valid:
              *             - Set Vote of all connected_players to NOTHING
              *             - Set Players in Bet with connected_players
              *             - If valid, set is_bet_flag_unlocked to true
              *             - If not valid, set is_bet_flag_unlocked to false and set next Bet to null
              *         - Create new next Bet with <number> 
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
