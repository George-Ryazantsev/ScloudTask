using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Interfaces
{
    public interface ILogFormatter
    {
        string Format(LogLevel level, string message, DateTime timestamp);
    }
}
