namespace ErikTheCoder.Brainstorm.Utilities.Random;


public sealed class ThreadsafeRandom : IThreadsafeRandom
{
    private System.Random _random;
    private object _lock;


    public ThreadsafeRandom() : this(null)
    {
    }


    public ThreadsafeRandom(int seed) : this((int?)seed)
    {
    }


    private ThreadsafeRandom(int? seed)
    {
        _random = seed.HasValue ? new System.Random(seed.Value) : new System.Random();
        _lock = new object();
    }


    public void Dispose()
    {
        lock (_lock)
        {
            _random = null;
        }
        _lock = null;
    }


    public int Next()
    {
        lock (_lock)
        {
            return _random.Next();
        }
    }


    public int Next(int exclusiveMax)
    {
        lock (_lock)
        {
            return _random.Next(exclusiveMax);
        }
    }


    public int Next(int inclusiveMin, int exclusiveMax)
    {
        lock (_lock)
        {
            return _random.Next(inclusiveMin, exclusiveMax);
        }
    }


    public double NextDouble()
    {
        lock (_lock)
        {
            return _random.NextDouble();
        }
    }


    public double NextDouble(double max) => NextDouble(0, max);


    public double NextDouble(double min, double max)
    {
        var range = max - min;
        if (range < -double.Epsilon) throw new ArgumentOutOfRangeException(nameof(min), $"The range between {nameof(min)} and {nameof(max)} is smaller than is possible to represent with a double.");
        lock (_lock)
        {
            return min + (_random.NextDouble() * range);
        }
    }


    public void NextBytes(byte[] bytes)
    {
        lock (_lock)
        {
            _random.NextBytes(bytes);
        }
    }
}