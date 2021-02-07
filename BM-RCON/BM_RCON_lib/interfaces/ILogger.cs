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
        /// Trace logging (highest verbosity)
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Trace(string msg);

        /// <summary>
        /// Debug logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Debug(string msg);

        /// <summary>
        /// Info logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Info(string msg);

        /// <summary>
        /// Warning logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Warning(string msg);

        /// <summary>
        /// Error logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Error(string msg);

        /// <summary>
        /// Fatal logging
        /// </summary>
        /// <param name="msg">Message to log</param>
        void Fatal(string msg);

        /// <summary>
        /// Set state of debug logging
        /// </summary>
        /// <param name="state">The state to set</param>
        void SetDebug(bool state);

        /// <summary>
        /// Check if debug is enabled
        /// </summary>
        /// <returns>Returns current state of debug logging</returns>
        bool IsDebugEnabled();

        /// <summary>
        /// Set state of trace logging
        /// </summary>
        /// <param name="state">The state to set</param>
        void SetTrace(bool state);

        /// <summary>
        /// Check if trace is enabled
        /// </summary>
        /// <returns>Returns current state of trace logging</returns>
        bool IsTraceEnabled();
    }
}
