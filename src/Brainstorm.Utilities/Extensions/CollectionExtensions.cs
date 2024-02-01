using ErikTheCoder.Brainstorm.Utilities.Random;


namespace ErikTheCoder.Brainstorm.Utilities.Extensions;


public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this List<T> list) => (list == null) || (list.Count == 0);


    public static void Shuffle<T>(this List<T> items, IThreadsafeRandom random)
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


    public static ListDiff<TId> CalculateDiff<T, TId>(this List<T> originalList, List<T> updatedList, Func<T, TId> getId) => CalculateDiff(originalList, updatedList, getId, getId);


    public static ListDiff<TId> CalculateDiff<TOriginal, TUpdated, TId>(this List<TOriginal> originalList, List<TUpdated> updatedList, Func<TOriginal, TId> getOriginalId, Func<TUpdated, TId> getUpdatedId)
    {
        var diff = new ListDiff<TId>();

        // Extract IDs from the original and updated lists into two HashSets.
        var originalSids = new HashSet<TId>();
        foreach (var item in originalList) originalSids.Add(getOriginalId(item));
        var updatedSids = new HashSet<TId>();
        foreach (var item in updatedList) updatedSids.Add(getUpdatedId(item));
        
        // Determine which items have been added to the updated list.
        foreach (var sid in updatedSids) if (!originalSids.Contains(sid)) diff.Added.Add(sid);

        // Determine which items remain in the updated list and which were deleted from the updated list.
        foreach (var sid in originalSids)
        {
            if (updatedSids.Contains(sid)) diff.Remaining.Add(sid); // Item remains in updated list.
            else diff.Removed.Add(sid); // Item was removed from updated list.
        }

        return diff;
    }
}