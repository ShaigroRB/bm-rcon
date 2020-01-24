using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.BM_RCON_lib
{
    class RCON_Event
    {
        short json_size;
        short eventID;
        string json_str;

        public RCON_Event(short json_size, short eventID, string json)
        {
            // the json size takes into account the end delimiter which length is 3 bits
            // real size of the json is json - 3
            this.json_size = json_size;
            // the event ID is in also in the json, if needed
            this.eventID = eventID;
            this.json_str = json;
        }

        public short JsonSize
        {
            get
            {
                return json_size;
            }
        }

        public short EventID
        {
            get
            {
                return eventID;
            }
        }

        public string JsonAsString
        {
            get
            {
                return json_str;
            }
        }

        public dynamic JsonAsObj
        {
            get
            {
                return JObject.Parse(json_str);
            }
        }
    }
}
