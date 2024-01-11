namespace HA.Application.UseCases.Categories.GetCategories;

/// <summary>
/// Информация о категории.
/// </summary>
public class GetCategoryListDto
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
