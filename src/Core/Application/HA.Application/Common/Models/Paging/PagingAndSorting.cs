namespace HA.Application.Common.Models.Paging;

/// <summary>
/// Пагинация и сортировка.
/// </summary>
public abstract record PagingAndSorting : Paging, ISorted
{
    public string? Sorting { get; init; } = null;
}
