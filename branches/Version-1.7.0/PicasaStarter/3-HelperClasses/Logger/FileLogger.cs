using System;
using System.IO;
using System.Text;
using System.Globalization;

namespace HelperClasses.Logger
{
    /// <remarks>
    /// Log messages to a file location.
    /// </remarks>
    public class FileLogger
    {
        // Internal log file
        private FileInfo _logFile;

        public FileInfo LogFile
        {
            get { return _logFile; }
            set 
            { 
                if (!value.Directory.Exists)
                    value.Directory.Create();
                _logFile = value;
            }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public FileLogger()
        {
            this._logFile = new FileInfo("C:\\mylog.log");
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="message">Message to log. </param>
        /// <param name="level">Error severity level. </param>
        public void Log(Log.Level level, string message)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            StringBuilder messageBuilder = new StringBuilder();

            try
            {
                fileStream = _logFile.Open(FileMode.OpenOrCreate,
                          FileAccess.Write, FileShare.Read);
                writer = new StreamWriter(fileStream);

                // Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End);

                // Create the message
                messageBuilder.Append(System.DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"))
                   .Append(" | ").Append(level.ToString()).Append(" | ").Append(messageBuilder);

                // Force the write to the underlying file
                writer.WriteLine(messageBuilder.ToString());
                writer.Flush();
            }
            finally
            {
                if (writer != null) 
                    writer.Close();
            }
        }
    }
}
