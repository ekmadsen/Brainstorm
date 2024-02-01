using System.Diagnostics;


namespace ErikTheCoder.Brainstorm.Utilities;


// TODO: Determine how to provide async methods. See https://stackoverflow.com/questions/22664392/await-console-readline.
public static class ThreadsafeConsole
{
    private const string _elapsedSecondsFormat = "000.000";
    private const string _threadIdFormat = "00";
    private static readonly object _lock = new();


    public static void Write(string message, ConsoleColor color = ConsoleColor.White)
    {
        lock (_lock)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }


    public static void WriteLine()
    {
        lock (_lock)
        {
            Console.WriteLine();
        }
    }


    public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, Stopwatch stopwatch = null, bool includeThreadName = false)
    {
        var elapsed = stopwatch is null
            ? string.Empty
            : $"{stopwatch.Elapsed.TotalSeconds.ToString(_elapsedSecondsFormat)}  ";

        var threadName = includeThreadName
            ? $"Thread{Thread.CurrentThread.ManagedThreadId.ToString(_threadIdFormat)}  "
            : string.Empty;

        lock (_lock)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{elapsed}{threadName}{message}");
            Console.ResetColor();
        }
    }


    public static int Read()
    {
        lock (_lock)
        {
            return Console.Read();
        }
    }


    public static string ReadLine()
    {
        lock (_lock)
        {
            return Console.ReadLine();
        }
    }
}