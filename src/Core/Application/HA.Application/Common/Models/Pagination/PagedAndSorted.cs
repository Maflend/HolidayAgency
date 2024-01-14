namespace HA.Application.Common.Models.Pagination;

/// <summary>
/// Пагинация и сортировка.
/// </summary>
public abstract record PagedAndSorted : Paged, ISorted
{
    public string? Sorting { get; init; } = null;
}
