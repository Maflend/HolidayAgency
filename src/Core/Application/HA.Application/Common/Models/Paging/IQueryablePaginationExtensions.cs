using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Common.Models.Paging;
public static class IQueryablePaginationExtensions
{
    public static async Task<PaginatedList<TItem>> ToPaginatedListAsync<TItem>(
        this IQueryable<TItem> source,
        IPaged paged,
        CancellationToken cancellationToken = default)
        where TItem : class
    {
        var totalCount = source.Count();
        var totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)paged.PageSize);
        var items = await source.Skip(paged.PageNumber * paged.PageSize).Take(paged.PageSize).ToListAsync(cancellationToken);

        return new PaginatedList<TItem>(paged.PageNumber, paged.PageSize, totalCount, totalPages, items);
    }
}
