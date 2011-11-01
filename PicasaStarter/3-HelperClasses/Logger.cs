using System;

namespace Logger
{
    /// <remarks>
    /// Abstract class to dictate the format for the logs that our logger will use.
    /// </remarks>
    public abstract class Logger
    {
        /// <value>Available message severities</value>
        public enum Level
        {
            All = 1,
            Debug = 2,
            Info = 3,
            Warn = 4,
            Error = 5,
            Fatal = 6
        }

        public abstract void Log(Level Level, string Message);
        public void Log(Level Level, Exception Message)
        {
            Log(Level, Message);
        }
    }
}
