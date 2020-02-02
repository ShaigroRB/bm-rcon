using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.mods.betmode
{
    class Profile
    {
        int profileID;
        int storeID;

        public Profile(int profileID, int storeID)
        {
            this.profileID = profileID;
            this.storeID = storeID;
        }

        public int ProfileID
        {
            get;
        }

        public int StoreID
        {
            get;
        }

        public bool Equals(Profile profile)
        {
            return (this.profileID == profile.ProfileID) && (this.storeID == profile.StoreID);
        }
    }
}
