using HA.Application.Common.Mapping;
using HA.Domain.Categories;
using HA.Domain.Common;

namespace HA.Application.UseCases.Categories.GetCategories;

/// <summary>
/// Информация о категории.
/// </summary>
public class GetCategoriesResponse : IHasId, IMapFrom<Category>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Цена за час.
    /// </summary>
    public decimal PriceOfHourse { get; set; }
}
