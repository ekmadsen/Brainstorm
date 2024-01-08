using System.Security.Cryptography;


namespace ErikTheCoder.Brainstorm.Utilities.Random;


public sealed class ThreadsafeCryptoRandom : IThreadsafeRandom
{
    private RandomNumberGenerator _random = RandomNumberGenerator.Create();
    private object _lock = new();


    public void Dispose()
    {
        lock (_lock)
        {
            _random.Dispose();
            _random = null;
        }
        _lock = null;
    }


    public int Next() => Next(0, int.MaxValue);


    public int Next(int exclusiveMax) => Next(0, exclusiveMax);


    public int Next(int inclusiveMin, int exclusiveMax)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(exclusiveMax, inclusiveMin);
        var range = exclusiveMax - inclusiveMin;
        if (range == 0) return inclusiveMin;

        var randomBytes = new byte[sizeof(int)];
        NextBytes(randomBytes);
        var random = BitConverter.ToUInt32(randomBytes, 0);
        return inclusiveMin + (int)(random % range);
    }


    public double NextDouble() => NextDouble(0, 1d);


    public double NextDouble(double max) => NextDouble(0, max);


    public double NextDouble(double min, double max)
    {
        var range = max - min;
        if (range < -double.Epsilon) throw new ArgumentOutOfRangeException(nameof(min), $"The range between {nameof(min)} and {nameof(max)} is smaller than is possible to represent with a double.");

        var randomBytes = new byte[sizeof(ulong)];
        NextBytes(randomBytes);

        // Shift bits 11 and 53 based on double's mantissa bits.
        // See https://stackoverflow.com/a/2854635/8992299.
        var randomLong = BitConverter.ToUInt64(randomBytes, 0) / (1ul << 11);
        var randomDouble = randomLong / (double)(1ul << 53);
        return min + (randomDouble * range);
    }


    public void NextBytes(byte[] bytes)
    {
        lock (_lock)
        {
            _random.GetBytes(bytes);
        }
    }
}
