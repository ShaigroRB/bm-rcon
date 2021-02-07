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
        private readonly ILogger logger;

        /// <summary>
        /// Contains information on a RCON event
        /// </summary>
        /// <param name="json_size">Size of JSON (number of bytes)</param>
        /// <param name="eventID">ID of the event (see enum EventType)</param>
        /// <param name="json">The JSON given as string</param>
        /// <param name="logger">The logger used</param>
        public RCON_Event(short json_size, short eventID, string json, ILogger logger)
        {
            logger.Trace("Instanciation of an event.");

            logger.Trace($"JSON size: {json_size}, id: {eventID}, json: {json}");
            // the json size takes into account the end delimiter which length is 3 bits
            // real size of the json is json - 3
            this.JsonSize = json_size;

            // the event ID is in also in the json, if needed
            this.EventID = eventID;

            // json as string
            this.JsonAsString = json;

            logger.Trace("Parsing the json as an object.");
            // json as object
            this.JsonAsObj = JObject.Parse(json);
            // logger used for Print method
            this.logger = logger;
            logger.Trace("Finished the instanciation of the event.");
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
        /// Use the logger to output the JSON size, the event ID and the JSON
        /// </summary>
        public void Print()
        {
            logger.Trace("RCON_Event.Print() starts.");
            logger.Debug("Printing the event info of an event.");
            logger.Info("JSON size: " + JsonSize.ToString());
            logger.Info("Event ID: " + EventID.ToString());
            logger.Info("JSON: " + JsonAsString);
            logger.Trace("RCON_Event.Print() finishes.");
        }
    }
}
