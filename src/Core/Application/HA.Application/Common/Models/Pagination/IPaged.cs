using System.ComponentModel;

namespace HA.Application.Common.Models.Pagination;

/// <summary>
/// Пагинация.
/// </summary>
public interface IPaged
{
    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int PageNumber { get; init; }

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; init; }
}
