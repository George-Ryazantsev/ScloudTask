using LoggingLibrary.Interfaces;
using LoggingLibrary.Loggers;

namespace LoggingLibrary
{
    internal class Program
    {
        private static void Main()
        {
            var settings = new LoggerSettings
            {
                FilePath = "log.txt",
                TimeFormat = "yyyy-MM-dd|HH:mm:ss",
                LevelReplacements = new Dictionary<LogLevel, string>
                {
                    { LogLevel.Information, "INFORM" },
                    { LogLevel.Warning, "WARN" },                    
                },
                MaxLines = 3
            };

            Log(settings);
        }
        private static void Log(LoggerSettings settings)
        {
            ILogFormatter formatter = new DefaultLogFormatter(settings.TimeFormat, settings.LevelReplacements);

            ILogger logger = new SmartLogger(settings, formatter);

            logger.Log(LogLevel.Information, "Информационное сообщение");
            logger.Log(LogLevel.Warning, "Предупреждение");
            logger.Log(LogLevel.Error, "Ошибка");

            logger.Log(LogLevel.Warning, "Проверка переполнения");
        }
    }
}