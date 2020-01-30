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
            // not a constant because we don't know yet no other enemies will be added
            int total_nb_enemies = Enum.GetNames(typeof(lib.EnemyID)).Length;
            // there is 40 vices and it won't change
            int total_nb_vices = 40;

            this.bet = bet;
            this.enemies = new int[total_nb_enemies];
            this.vices = new int[total_nb_vices];
            // maximum of players in a server is 20 people
            this.players_in_bet = new Player[20];

            randomizeBosses();
            randomizeVices();
        }

        private void randomizeBosses()
        {
            int first_boss = (int)lib.EnemyID.indigo;
            int last_boss = (int)lib.EnemyID.roxxy;

            Random rnd = new Random();
            int boss = 0;

            for (int i = 0; i < this.bet; i++)
            {
                boss = rnd.Next(first_boss, last_boss);
                this.enemies[boss] += 1;
            }
        }

        private void randomizeVices()
        {
            int first_vice = (int)lib.ViceID.lager;
            int last_vice = (int)lib.ViceID.water;

            Random rnd = new Random();
            int vice = 0;

            for (int i = 0; i < this.bet; i++)
            {
                vice = rnd.Next(first_vice, last_vice);
                this.enemies[vice] += 1;
            }
        }

        public void SetPlayersInBet(Player[] players)
        {
            Array.Copy(players, this.players_in_bet, players.Length);
        }
    }
}
