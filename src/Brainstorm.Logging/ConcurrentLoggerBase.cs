namespace Brainstorm.Logging;


/// <summary>
/// This zero latency, threadsafe class queues logs and writes them on a ThreadPool thread.  This avoids blocking the caller to wait for I/O.
/// </summary>
public abstract class ConcurrentLoggerBase
{
}