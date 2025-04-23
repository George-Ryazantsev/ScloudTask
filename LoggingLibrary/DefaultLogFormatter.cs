using LoggingLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace LoggingLibrary
{
    public class DefaultLogFormatter : ILogFormatter
    {
        private readonly string _timeFormat;
        private readonly Dictionary<LogLevel, string> levelReplacements;

        public DefaultLogFormatter(string timeFormat, Dictionary<LogLevel, string> levelReplacements)
        {
            _timeFormat = timeFormat;
            this.levelReplacements = levelReplacements;
        }

        public string Format(LogLevel level, string message, DateTime timestamp)
        {
            string levelText = levelReplacements.TryGetValue(level, out string replacement)
                ? replacement
                : level.ToString();

            return $"{timestamp.ToString(_timeFormat)} | {levelText} | {message}";
        }
    }
}
