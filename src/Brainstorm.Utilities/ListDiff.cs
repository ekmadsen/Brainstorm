namespace ErikTheCoder.Brainstorm.Utilities;

public class ListDiff<T>
{
    public HashSet<T> Added { get; } = [];
    public HashSet<T> Removed { get; } = [];
    public HashSet<T> Remaining { get; } = [];
}