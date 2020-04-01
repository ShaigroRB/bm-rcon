using System;
using System.Collections.Generic;
using System.Text;

namespace BM_RCON.BM_RCON_lib
{
    interface ILogger
    {
        /// <summary>
        /// Default logging (no type of log specified)
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Log(string msg);

        /// <summary>
        /// Info logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void LogInfo(string msg);

        /// <summary>
        /// Debug logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void LogDebug(string msg);

        /// <summary>
        /// Error logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void LogError(string msg);

        /// <summary>
        /// Warning logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void LogWarning(string msg);

        /// <summary>
        /// Enable debug logging
        /// </summary>
        void EnableDebug();

        /// <summary>
        /// Disable debug logging
        /// </summary>
        void DisableDebug();

        /// <summary>
        /// Toggle debug logging
        /// </summary>
        /// <returns>Returns current state of debug logging</returns>
        bool ToggleDebug();
    }
}
