using LoggingLibrary.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace LoggingLibrary.Loggers
{
    public class SmartLogger : ILogger
    {
        private readonly LoggerSettings _settings;
        private readonly ILogFormatter _formatter;
        private FileLogger _currentLogger;
        private string _currentPath;
        public SmartLogger(LoggerSettings settings, ILogFormatter formatter)
        {
            _settings = settings;
            _formatter = formatter;

            _currentPath = _settings.FilePath;
            _currentLogger = new FileLogger(_currentPath, _formatter);
        }
        public string GetNewFilePath(string oldPath)
        {
            string dir = Path.GetDirectoryName(oldPath);
            string baseName = Path.GetFileNameWithoutExtension(oldPath);
            string ext = Path.GetExtension(oldPath);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string newPath = Path.Combine(dir, $"{baseName}_{timestamp}{ext}");

            return newPath;
        }

        public bool IsHugeFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            int lineCount = File.ReadLines(filePath).Count();

            if (lineCount >= _settings.MaxLines)
            {
                return true;
            }

            return false;
        }

        public void Log(LogLevel level, string message)
        {
            if (IsHugeFile(_currentPath))
            {
                _currentPath = GetNewFilePath(_currentPath);
                _currentLogger = new FileLogger(_currentPath, _formatter);

                Console.WriteLine($"Запись в новый файл: {_currentPath}");
            }

            _currentLogger.Log(level, message);
        }
    }
}
