namespace C4WX1.Tests.Extensions;

public static class EnumerableExtensions
{
    public static bool IsAscendingOrder<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        var selected = source.Select(selector);
        var sorted = selected.OrderBy(x => x);
        return selected.SequenceEqual(sorted);
    }

    public static bool IsDescendingOrder<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        var selected = source.Select(selector);
        var sorted = selected.OrderByDescending(x => x);
        return selected.SequenceEqual(sorted);
    }
}
