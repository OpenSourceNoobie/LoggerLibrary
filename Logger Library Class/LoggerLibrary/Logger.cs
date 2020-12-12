using System;
using System.IO;
using System.Threading.Tasks;

namespace LoggerLibrary
{
    /// <summary>
    /// A Class to log activity to a file
    /// </summary>
    public class Logger
    {
        #region Public Delegate

        private delegate Task LoggingEvent();

        #endregion
        
        #region Public Event

        private event LoggingEvent Log;

        #endregion

        #region Private Members

        /// <summary>
        /// The Current Time in format HH:mm:ss
        /// </summary>
        private string currentTime { get { return $"{DateTime.Now.ToString("HH:mm:ss")}"; } }

        /// <summary>
        /// The Message to log
        /// </summary>
        private string mMessage { get; set; }

        /// <summary>
        /// The Error Level
        /// </summary>
        private ErrorLevel mError { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Instanziate a new Logger class to log into a file asynchronously
        /// </summary>
        public Logger()
            : this(Path.Combine(Directory.GetCurrentDirectory() + "Data"), "LoggingActivity.log")
        { }

        /// <summary>
        /// Instanziate a new Logger class to log into a file asynchronously
        /// </summary>
        /// <param name="directoryPath">The directory path where the fileName param will be stored. Default path will be <see cref="Directory.GetCurrentDirectory()"/>.</param>
        /// <param name="fileName">The name of the Logging file. Default will be LoggingActivity.log</param>
        public Logger(string directoryPath, string fileName)
        {
            ValidateDirectory(directoryPath);

            _directoryPath = directoryPath;
            _lPath = fileName;
            Log += logFileAsync;
        }

        #endregion

        #region Public Properties

        private string _directoryPath;
        /// <summary>
        /// Logging File Directory Name. Default set to - <see cref="Directory.GetCurrentDirectory()"/>\Data\
        /// </summary>
        public string DirectoryName
        {
            get { return _directoryPath; }
        }

        private string _lPath;
        /// <summary>
        /// Logging file Name. Default Set to - Log.txt
        /// </summary>
        public string LoggingFileName
        {
            get { return _lPath; }
        }

        /// <summary>
        /// The whole path of the file it logs to.
        /// </summary>
        public string LogFileFullPath
        {
            get { return $@"{DirectoryName}\{LoggingFileName}"; }
        }

        /// <summary>
        /// How to Display the string in the Log File
        /// </summary>
        public string LogFormat
        {
            get { return $"{currentTime} | {mError} | {mMessage}"; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Log string to file <see cref="LoggingFileName"/>. 
        /// </summary>
        /// <param name="message">string type to log to a file</param>
        public async Task LogFileAsync(string message)
        {
            await LogFileAsync(message, ErrorLevel.None);
        }

        /// <summary>
        /// Log string to file <see cref="LoggingFileName"/>. 
        /// </summary>
        /// <param name="message">string type to log to a file</param>
        /// <param name="console">Show logged message in the console. true by Default</param>
        /// <returns></returns>
        public async Task LogFileAsync(string message, ErrorLevel errorLevel)
        {
            mMessage = message;
            mError = errorLevel;

            await Log();

#if DEBUG
            //  Get LogFormat and put 'DEBUG' in fromt of the string
            //_lFormat = $"DEBUG: {LogFormat}";
            Console.WriteLine(LogFormat);
#endif
        }

        #endregion

        #region Private Events Method

        /// <summary>
        /// Private <see cref="LoggingEvent"/> delegate event call
        /// </summary>
        /// <returns></returns>
        private async Task logFileAsync()
        {
            using (StreamWriter sw = new StreamWriter(LogFileFullPath, true))
                await sw.WriteLineAsync($"{LogFormat}");
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Validates that the Directory Exist, if not Create it
        /// </summary>
        /// <param name="path"></param>
        private void ValidateDirectory(string path)
        {
            //  Path Check Here
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        #endregion

        #region Public Overrides


        public override string ToString()
        {
            return $"DirectoryName:  \t{DirectoryName}\n" +
                $"LoggingFileName:\t{LoggingFileName}\n" +
                $"LogFileFullPath:\t{LogFileFullPath}\n";
        }

        #endregion
    }
}
