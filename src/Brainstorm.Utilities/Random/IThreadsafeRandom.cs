namespace ErikTheCoder.Brainstorm.Utilities.Random;


public interface IThreadsafeRandom : IDisposable
{
    /// <summary>
    /// Returns a non-negative random integer.
    /// </summary>
    int Next();


    /// <summary>
    /// Returns a non-negative random integer that is less than the specified maximum.
    /// </summary>
    int Next(int exclusiveMax);


    /// <summary>
    /// Returns a random integer that is within a specified range.
    /// </summary>
    int Next(int inclusiveMin, int exclusiveMax);


    /// <summary>
    /// Returns a random floating-point number between 0.0 and 1.0.
    /// </summary>
    double NextDouble();


    /// <summary>
    /// Returns a random floating-point number between 0.0 and Max.
    /// </summary>
    double NextDouble(double max);


    /// <summary>
    /// Returns a random floating-point number between Min and Max.
    /// </summary>
    double NextDouble(double min, double max);


    /// <summary>
    /// Fills the elements of the specified byte array with random numbers.
    /// </summary>
    void NextBytes(byte[] bytes);
}
