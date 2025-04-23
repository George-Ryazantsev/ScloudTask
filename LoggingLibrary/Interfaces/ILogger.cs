using System;

namespace LoggingLibrary.Interfaces
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}
