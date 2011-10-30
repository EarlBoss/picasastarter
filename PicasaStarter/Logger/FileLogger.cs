using System;
using System.IO;
using System.Text;
using System.Globalization;


namespace Logger
{
    /// <remarks>
    /// Log messages to a file location.
    /// </remarks>
    public class FileLogger : Logger
    {
        // Internal log file name value
        private string _FileName = "";
        /// <value>Get or set the log file name</value>
        public string FileName
        {
            get { return this._FileName; }
            set { this._FileName = value; }
        }

        // Internal log file location value
        private string _FileLocation = "";
        /// <value>Get or set the log file directory location</value>

        public string FileLocation
        {
            get { return this._FileLocation; }
            set
            {
                this._FileLocation = value;
                // Verify a '\' exists on the end of the location
                if (this._FileLocation.LastIndexOf("\\") !=
                           (this._FileLocation.Length - 1))
                {
                    this._FileLocation += "\\";
                }
                if (!Directory.Exists(_FileLocation))
                    Directory.CreateDirectory(_FileLocation);

            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public FileLogger()
        {
            this.FileLocation = "C:\\";
            this.FileName = "mylog.txt";
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="Message">Message to log. </param>
        /// <param name="Level">Error severity level. </param>
        public override void Log(Logger.Level Level, string Message)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            StringBuilder message = new StringBuilder();

            try
            {
                fileStream = new FileStream(this._FileLocation +
                          this._FileName, FileMode.OpenOrCreate,
                          FileAccess.Write, FileShare.Read);
                writer = new StreamWriter(fileStream);

                // Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End);

                // Create the message
                message.Append(System.DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo))
                   .Append(" | ").Append(Level.ToString()).Append(" | ").Append(Message);

                // Force the write to the underlying file
                writer.WriteLine(message.ToString());
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
