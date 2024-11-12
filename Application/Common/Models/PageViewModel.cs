using Microsoft.EntityFrameworkCore;

namespace Application.Common.Models;

public class PageViewModel<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    private PageViewModel(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public static async Task<PageViewModel<T>> CreateAsync(
        IQueryable<T> source,
        int pageNumber,
        int pageSize
    )
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PageViewModel<T>(items, count, pageNumber, pageSize);
    }
}
