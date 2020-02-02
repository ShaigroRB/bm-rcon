using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.mods.betmode
{
    class Profile
    {
        string profileID;
        string storeID;

        public Profile(string profileID, string storeID)
        {
            this.profileID = profileID;
            this.storeID = storeID;
        }

        public string ProfileID
        {
            get;
        }

        public string StoreID
        {
            get;
        }

        public bool Equals(Profile profile)
        {
            return (this.profileID.Equals(profile.ProfileID)) && (this.storeID.Equals(profile.StoreID));
        }
    }
}
