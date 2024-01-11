namespace HA.Application.Common.Models.Paging;

/// <summary>
/// Пагинация и сортировка.
/// </summary>
public abstract record PagingAndSorting : IPaged, ISorted
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; }
    public string? Sorting { get; init; } = null;
}
