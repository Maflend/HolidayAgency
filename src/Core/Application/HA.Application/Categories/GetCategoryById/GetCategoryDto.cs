namespace HA.Application.Categories.GetCategoryById;

/// <summary>
/// Информация о категории.
/// </summary>
public class GetCategoryDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена за час.
    /// </summary>
    public decimal PriceOfHourse { get; set; }
}

