using System;
using System.Windows;
using System.Windows.Forms;

namespace Logger
{
    /// <summary>
    /// Write out messages using the logging provider.
    /// 
    /// This class shoul be implemented for each application and it is here you can specify (hard coded!) 
    /// which logging levels to log which way...
    /// </summary>
    public static class Log
    {
        private static FileLogger _FileLogger = new FileLogger();

        /// <summary>
        /// Static instance of the log manager.
        /// </summary>
        static Log()
        {
            try
            {
                _FileLogger.FileLocation = "C:\\temp\\";
                _FileLogger.FileName = "PicasaStarter.log";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void All(Exception Message)
        {
            _FileLogger.Log(Logger.Level.All, Message);
        }
        public static void All(string Message)
        {
            _FileLogger.Log(Logger.Level.All, Message);
        }

        public static void Debug(Exception Message)
        {
            _FileLogger.Log(Logger.Level.Debug, Message);
        }
        public static void Debug(string Message)
        {
            _FileLogger.Log(Logger.Level.Debug, Message);
        }

        public static void Info(Exception Message)
        {
            _FileLogger.Log(Logger.Level.Info, Message);
        }
        public static void Info(string Message)
        {
            _FileLogger.Log(Logger.Level.Info, Message);
        }

        public static void Warn(Exception Message)
        {
            _FileLogger.Log(Logger.Level.Warn, Message);
        }
        public static void Warn(string Message)
        {
            _FileLogger.Log(Logger.Level.Warn, Message);
        }

        public static void Error(Exception Message)
        {
            _FileLogger.Log(Logger.Level.Error, Message);
        }
        public static void Error(string Message)
        {
            _FileLogger.Log(Logger.Level.Error, Message);
        }

        public static void Fatal(Exception Message)
        {
            _FileLogger.Log(Logger.Level.Fatal, Message);
        }
        public static void Fatal(string Message)
        {
            _FileLogger.Log(Logger.Level.Fatal, Message);
        }
    }
}