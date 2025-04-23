using LoggingLibrary.Interfaces;
using System;
using System.IO;

namespace LoggingLibrary.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly ILogFormatter _formatter;

        public FileLogger(string filePath, ILogFormatter formatter)
        {
            _filePath = filePath;
            _formatter = formatter;
        }

        public void Log(LogLevel level, string message)
        {
            string formattedMessage = _formatter.Format(level, message, DateTime.Now);
            File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
        }
    }
}
