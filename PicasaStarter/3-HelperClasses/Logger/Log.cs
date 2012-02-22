using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace HelperClasses.Logger
{
    /// <summary>
    /// Write out messages using the logging provider.
    /// 
    /// This class should be implemented for each application and it is here you can specify (hard coded!) 
    /// which logging levels to log which way...
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// In a release build, starting at which level of logging do we log to file? 
        /// </summary>
        public static Level LogLevelFile = Level.Info;

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

        private static FileLogger _FileLogger = new FileLogger();

        /// <summary>
        /// Static instance of the log manager.
        /// </summary>
        static Log()
        {
            try
            {
                string LogFilePath = Path.GetTempPath() +"PicasaStarter\\Log\\"
                       + System.DateTime.Now.ToString("yyyy'-'MM'-'dd") + ".log";
                _FileLogger.LogFile = new FileInfo(LogFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void LogIt(Level level, Exception ex)
        {
            _FileLogger.Log(level, ex.Message);
        }

        private static void LogIt(Level level, string message)
        {
            // If compiled in debug... log everything, otherwise only what needs to be logged..
#if DEBUG
            _FileLogger.Log(level, message);
#else
            if (level >= LogLevelFile)
                _FileLogger.Log(level, message);
#endif
        }

        public static void All(Exception Message)
        {
            LogIt(Level.All, Message);
        }
        public static void All(string Message)
        {
            LogIt(Level.All, Message);
        }

        public static void Debug(Exception Message)
        {
            LogIt(Level.Debug, Message);
        }
        public static void Debug(string Message)
        {
            LogIt(Level.Debug, Message);
        }

        public static void Info(Exception Message)
        {
            LogIt(Level.Info, Message);
        }
        public static void Info(string Message)
        {
            LogIt(Level.Info, Message);
        }

        public static void Warn(Exception Message)
        {
            LogIt(Level.Warn, Message);
        }
        public static void Warn(string Message)
        {
            LogIt(Level.Warn, Message);
        }

        public static void Error(Exception Message)
        {
            LogIt(Level.Error, Message);
        }
        public static void Error(string Message)
        {
            LogIt(Level.Error, Message);
        }

        public static void Fatal(Exception Message)
        {
            LogIt(Level.Fatal, Message);
        }
        public static void Fatal(string Message)
        {
            LogIt(Level.Fatal, Message);
        }
    }
}