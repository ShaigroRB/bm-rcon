using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.mods.betmode
{
    class Player
    {
        string name;
        string profile;
        // type of vice is the index in the list
        short[] vices;
        bool is_connected;
        bool is_alive;

        public Player(string name, string profile)
        {
            this.name = name;
            this.profile = profile;
            this.vices = new short[40];
            // when a player is created, it means the player just connected
            this.is_connected = true;
            this.is_alive = false;
        }
    }
}
