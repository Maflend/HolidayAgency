namespace HA.Application.Common.Models.Pagination;

/// <summary>
/// Сортировка.
/// </summary>
public interface ISorted
{
    /// <summary>
    /// Строка сортировки. Пример: Name ASC, Age DESC.
    /// </summary>
    public string? Sorting { get; init; }
}
