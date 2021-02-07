using System;
using System.Diagnostics;

namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Output logging to console
    /// </summary>
    class ConsoleLogger : ILogger
    {
        private bool isTrace;
        private bool isDebug;
        private bool isWritingAllowed;

        /// <summary>
        /// Initialize a ConsoleLogger
        /// </summary>
        /// <param name="isDebug">Set if Debug verbosity is enabled</param>
        /// <param name="isTrace">Set if Trace verbosity is enabled</param>
        public ConsoleLogger(bool isDebug = false, bool isTrace = false)
        {
            this.isTrace = isTrace;
            this.isDebug = isDebug;
            this.isWritingAllowed = false;
        }

        public void Log(string msg)
        {
            if (isWritingAllowed)
            {
                Console.WriteLine($"{DateTime.UtcNow} {msg}");
            }
        }

        public void Trace(string msg)
        {
            if (isTrace)
            {
                Log($"TRACE   | {msg}");
            }
        }

        public void Debug(string msg)
        {
            if (isDebug)
            {
                Log($"DEBUG   | {msg}");
            }
            else if (isTrace)
            {
                Log($"TRACE   | {msg}");
            }
        }

        public void Info(string msg)
        {
            Log($"INFO    | {msg}");
        }

        public void Warning(string msg)
        {
            Log($"WARNING | {msg}");
        }

        public void Error(string msg)
        {
            Log($"ERROR   | {msg}");
        }

        public void Fatal(string msg)
        {
            Log($"FATAL   | {msg}");
        }

        public bool IsDebugEnabled()
        {
            return isDebug;
        }

        public bool IsTraceEnabled()
        {
            return isTrace;
        }

        public void SetDebug(bool state)
        {
            isDebug = state;
        }

        public void SetTrace(bool state)
        {
            isTrace = state;
        }

        public int StartWriting()
        {
            // check if there is a console available
            isWritingAllowed = (Process.GetCurrentProcess().MainWindowHandle != IntPtr.Zero);
            return isWritingAllowed ? 0 : 1;
        }

        public int StopWriting()
        {
            isWritingAllowed = false;
            return 0;
        }
    }
}
