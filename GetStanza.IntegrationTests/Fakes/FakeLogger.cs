using Microsoft.Extensions.Logging;

namespace GetStanza.IntegrationTests.Fakes;

public class FakeLogger<T> : ILogger<T>
{
    //TODO: Add records field that stores everything that we can pull from
    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        throw new NotImplementedException();
    }
}