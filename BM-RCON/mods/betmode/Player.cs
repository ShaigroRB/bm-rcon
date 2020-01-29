using System;
using System.Collections.Generic;
using System.Text;
using ViceID = BM_RCON.BM_RCON_lib.ViceID;

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

        public string Profile
        {
            get;
        }

        public short[] Vices
        {
            get;
        }

        public bool IsConnected
        {
            get
            {
                return this.is_connected;
            }
            
            set
            {
                this.is_connected = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.is_alive;
            }
            
            set
            {
                this.is_alive = value;
            }
        }
    }
}
