namespace Commons.Pagination;

/// <summary>
/// Represents a page of results with cursor-based pagination.
/// </summary>
/// <typeparam name="T">The type of items in the page.</typeparam>
/// <param name="Items">The items in this page.</param>
/// <param name="NextCursor">The cursor to fetch the next page, or null if no more pages.</param>
/// <param name="HasMore">Whether there are more items after this page.</param>
public sealed record CursorPage<T>(IReadOnlyList<T> Items, Guid? NextCursor, bool HasMore)
{
    public static CursorPage<T> Empty => new([], null, false);

    public static CursorPage<T> Create(IReadOnlyList<T> items, Func<T, Guid> keySelector, int pageSize)
    {
        var hasMore = items.Count >= pageSize;
        var nextCursor = items.Count > 0 ? keySelector(items[^1]) : (Guid?)null;
        return new CursorPage<T>(items, nextCursor, hasMore);
    }
}
