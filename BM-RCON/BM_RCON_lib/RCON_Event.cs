using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Contains information on a RCON event
    /// </summary>
    class RCON_Event
    {
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
            this.JsonSize = json_size;
            // the event ID is in also in the json, if needed
            this.EventID = eventID;
            // json as string
            this.JsonAsString = json;
            // json as object
            this.JsonAsObj = JObject.Parse(json);
        }

        /// <summary>
        /// Getter for the size of the JSON
        /// </summary>
        public short JsonSize { get; }

        /// <summary>
        /// Getter for the ID of the event
        /// </summary>
        public short EventID { get; }

        /// <summary>
        /// Getter for the JSON (as a string)
        /// </summary>
        public string JsonAsString { get; }

        /// <summary>
        /// Getter for the JSON (as an object)
        /// </summary>
        public dynamic JsonAsObj { get; }

        /// <summary>
        /// Print in the console the JSON size, the event ID and the JSON
        /// </summary>
        public void Print()
        {
            Console.WriteLine("JSON size: {0}", JsonSize.ToString());
            Console.WriteLine("Event ID: {0}", EventID.ToString());
            Console.WriteLine("JSON: {0}", JsonAsString);
        }
    }
}
