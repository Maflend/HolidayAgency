using Microsoft.EntityFrameworkCore;

namespace HA.Application.Common.Models.Paging;

/// <summary>
/// Постраничный лист.
/// </summary>
/// <typeparam name="TItem">Тип элемента.</typeparam>
public class PaginatedList<TItem>
{
    /// <summary>
    /// Постраничный лист.
    /// </summary>
    /// <param name="source">Данные.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    public PaginatedList(int pageIndex, int pageSize, int totalCount, int totalPages, IReadOnlyList<TItem> items)
    {
        PageNumber = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalPages;
        Items = items;
    }

    public IReadOnlyList<TItem> Items { get; set; }

    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Общее кол-во элементов.
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Общее кол-во страниц.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    /// Есть предыдущая страница.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 0;

    /// <summary>
    /// Есть следующая страница.
    /// </summary>
    public bool HasNextPage => PageNumber + 1 < TotalPages;
}