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
        dynamic json_obj;

        /// <summary>
        /// Contains information on a RCON event
        /// </summary>
        /// <param name="json_size">Size of JSON (number of bytes)</param>
        /// <param name="eventID">ID of the event (see enum EventType)</param>
        /// <param name="json">The JSON given as string</param>
        public RCON_Event(short json_size, short eventID, string json)
        {
            // the json size takes into account the end delimiter which length is 3 bits
            // real size of the json is json - 3
            this.json_size = json_size;
            // the event ID is in also in the json, if needed
            this.eventID = eventID;
            // json as string
            this.json_str = json;
            // json as object
            this.json_obj = JObject.Parse(json);
        }

        public short JsonSize
        {
            get
            {
                return this.json_size;
            }
        }

        public short EventID
        {
            get
            {
                return this.eventID;
            }
        }

        public string JsonAsString
        {
            get
            {
                return this.json_str;
            }
        }

        public dynamic JsonAsObj
        {
            get
            {
                return this.json_obj;
            }
        }

        public void Print()
        {
            Console.WriteLine("JSON size: {0}", JsonSize.ToString());
            Console.WriteLine("Event ID: {0}", EventID.ToString());
            Console.WriteLine("JSON: {0}", JsonAsString);
        }
    }
}
