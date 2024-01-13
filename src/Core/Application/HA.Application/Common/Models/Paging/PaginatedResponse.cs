namespace HA.Application.Common.Models.Paging;

/// <remarks>
/// Постраничный лист.
/// </remarks>
/// <param name="pageIndex">Номер страницы.</param>
/// <param name="pageSize">Размер страницы.</param>
/// <param name="totalCount">Общее кол-во.</param>
/// <param name="totalPages">Общеее кол-во страниц.</param>
/// <param name="items">Элементы.</param>
/// <typeparam name="TItem">Тип элемента.</typeparam>
public class PaginatedResponse<TItem>(
    int pageIndex,
    int pageSize,
    int totalCount,
    int totalPages,
    IReadOnlyList<TItem> items)
{
    /// <summary>
    /// Элементы.
    /// </summary>
    public IReadOnlyList<TItem> Items { get; set; } = items;

    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int PageNumber { get; } = pageIndex;

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; } = pageSize;

    /// <summary>
    /// Общее кол-во элементов.
    /// </summary>
    public int TotalCount { get; } = totalCount;

    /// <summary>
    /// Общее кол-во страниц.
    /// </summary>
    public int TotalPages { get; } = totalPages;

    /// <summary>
    /// Есть предыдущая страница.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Есть следующая страница.
    /// </summary>
    public bool HasNextPage => PageNumber + 1 < TotalPages;
}