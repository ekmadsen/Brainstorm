﻿using Microsoft.Extensions.Logging;


namespace Brainstorm.Logging;


public class DatabaseLogger : ConcurrentLoggerBase, ILogger
{
    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        throw new NotImplementedException();
    }
}