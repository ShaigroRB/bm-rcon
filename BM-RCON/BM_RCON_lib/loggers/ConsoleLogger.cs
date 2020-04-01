using System;

namespace BM_RCON.BM_RCON_lib
{
    /// <summary>
    /// Output logging to console
    /// </summary>
    class ConsoleLogger : ILogger
    {
        private bool isDebug;

        public void DisableDebug()
        {
            isDebug = false;
        }

        public void EnableDebug()
        {
            isDebug = true;
        }

        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }

        public void LogDebug(string msg)
        {
            Console.WriteLine("[DEBUG]: {0}", msg);
        }

        public void LogError(string msg)
        {
            Console.WriteLine("[ERROR]: {0}", msg);
        }

        public void LogInfo(string msg)
        {
            Console.WriteLine("[INFO]: {0}", msg);
        }

        public void LogWarning(string msg)
        {
            Console.WriteLine("[WARNING]: {0}", msg);
        }

        public bool ToggleDebug()
        {
            isDebug = !isDebug;
            return isDebug;
        }
    }
}
