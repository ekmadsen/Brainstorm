using ErikTheCoder.Brainstorm.Utilities.Random;


namespace ErikTheCoder.Brainstorm.Utilities.Extensions;


public static class CollectionExtensions
{
    public static void Shuffle<T>(this IList<T> items, IThreadsafeRandom random)
    {
        // Use the Fischer-Yates algorithm.
        // See https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        var maxIndex = items.Count - 1;
        for (var index = maxIndex; index > 0; index--)
        {
            var swapIndex = random.Next(0, index + 1);
            (items[index], items[swapIndex]) = (items[swapIndex], items[index]);
        }
    }
}