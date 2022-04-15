using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookStoreApp
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly List<string> _logs;

        public MyLoggerProvider(List<string> logs)
        {
            _logs = logs;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger(_logs);
        }

        public void Dispose()
        {
        }

        private class MyLogger : ILogger
        {
            private readonly List<string> _logs;

            public MyLogger(List<string> logs)
            {
                _logs = logs;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return logLevel >= LogLevel.Information;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                _logs.Add(formatter(state, exception));
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }    
}
