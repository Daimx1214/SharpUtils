namespace SharpUtils;

/// <summary>Helpful extension methods for collections.</summary>
public static class CollectionExtensions
{
    /// <summary>Returns true when the collection is null or contains no elements.</summary>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source) =>
        source is null || !source.Any();

    /// <summary>Performs an action on each element and returns the source for chaining.</summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(action);
        foreach (var item in source) action(item);
        return source;
    }

    /// <summary>Splits a sequence into two lists: elements matching the predicate and elements that do not.</summary>
    public static (List<T> Matching, List<T> NotMatching) Partition<T>(
        this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        var matching = new List<T>();
        var notMatching = new List<T>();
        foreach (var item in source)
            (predicate(item) ? matching : notMatching).Add(item);
        return (matching, notMatching);
    }

    /// <summary>Splits a sequence into consecutive groups of at most <paramref name="size"/> elements.</summary>
    public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> source, int size)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        var batch = new List<T>(size);
        foreach (var item in source)
        {
            batch.Add(item);
            if (batch.Count == size)
            {
                yield return batch;
                batch = new List<T>(size);
            }
        }
        if (batch.Count > 0) yield return batch;
    }

    /// <summary>Returns a random element, or default when the sequence is empty.</summary>
    public static T? RandomElement<T>(this IEnumerable<T> source, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);
        var list = source as IList<T> ?? source.ToList();
        if (list.Count == 0) return default;
        return list[(random ?? Random.Shared).Next(list.Count)];
    }
}
