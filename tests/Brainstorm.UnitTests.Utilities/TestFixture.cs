using ErikTheCoder.Brainstorm.Utilities.Random;


namespace ErikTheCoder.Brainstorm.UnitTests.Utilities;


[SetUpFixture]
public static class ApplicationResources
{
    public static IThreadsafeRandom Random { get; private set; }
    public static IThreadsafeRandom CryptoRandom { get; private set; }


    [OneTimeSetUp]
    public static void SetUp()
    {
        Random = new ThreadsafeRandom();
        CryptoRandom = new ThreadsafeCryptoRandom();
    }


    [OneTimeTearDown]
    public static void TearDown()
    {
        CryptoRandom?.Dispose();
        CryptoRandom = null;
        Random?.Dispose();
        Random = null;
    }
}