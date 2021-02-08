using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Output logging to a file
    /// </summary>
    class FileLogger : ILogger
    {
        private bool isDebug;
        private bool isTrace;
        private readonly string path;
        private bool isWritingAllowed;
        private StreamWriter writer;

        /// <summary>
        /// Initializes a FileLogger
        /// </summary>
        /// <param name="path">The path to the file where the logs will be written</param>
        /// <param name="isDebug">Set if Debug verbosity is enabled</param>
        /// <param name="isTrace">Set if Trace verbosity is enabled</param>
        public FileLogger(string path = "bm_rcon_logs", bool isDebug = false, bool isTrace = false)
        {
            this.path = $"{path}_{DateTime.Now.ToString("yyyy-dd-M_HH-mm-ss")}.txt";
            this.isDebug = isDebug;
            this.isTrace = isTrace;
            this.isWritingAllowed = false;
        }

        public void Log(string msg)
        {
            if (isWritingAllowed)
            {
                writer.WriteLine($"{DateTime.UtcNow} {msg}");
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
            try
            {
                writer = new StreamWriter(path, true)
                {
                    AutoFlush = true
                };
                isWritingAllowed = true;
            }
            catch
            { 
                isWritingAllowed = false;
                return 1;
            }
            return 0;
        }

        public int StopWriting()
        {
            isWritingAllowed = false;
            try
            {
                writer.Close();
            }
            catch
            {
                return 1;
            }
            return 0;
        }
    }
}
