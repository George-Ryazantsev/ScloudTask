using System.Collections.Generic;

namespace LoggingLibrary
{
    public class LoggerSettings
    {
        public string FilePath { get; set; } = "log.txt";
        public string TimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
        public Dictionary<LogLevel, string> LevelReplacements { get; set; } = new Dictionary<LogLevel, string>();        
        public int MaxLines { get; set; } = 3;
    }
}
