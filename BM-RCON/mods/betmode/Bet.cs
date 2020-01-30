using System;
using System.Collections.Generic;
using System.Text;
using lib = BM_RCON.BM_RCON_lib;

namespace BM_RCON.mods.betmode
{
    class Bet
    {
        int bet;
        /*
         * In early waves, enemies will only be bosses.
         * In later waves, enemies will be bosses and minions.
        */
        int[] enemies;
        int[] vices;
        // players in bet are the connected players when the flag unlocks for the next wave
        Player[] players_in_bet;

        public Bet(int bet)
        {
            // not a constant because we don't know yet no other enemies/vices will be added
            int total_nb_enemies = Enum.GetNames(typeof(lib.EnemyID)).Length;
            int total_nb_vices = Enum.GetNames(typeof(lib.ViceID)).Length;

            this.bet = bet;
            this.enemies = new int[total_nb_enemies];
            this.vices = new int[total_nb_vices];

            randomizeBosses();
            randomizeVices();
        }

        private void randomizeBosses()
        {
        }

        private void randomizeVices()
        {

        }
    }
}
