using HA.Domain.Common;

namespace HA.Domain.Categories;

/// <summary>
/// Категория.
/// </summary>
public class Category : Entity
{
    #pragma warning disable CS8618
    private Category() { }
    #pragma warning restore CS8618

    public Category(string name, decimal priceOfHourse)
    {
        Name = name;
        PriceOfHourse = priceOfHourse;
    }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Цена в час.
    /// </summary>
    public decimal PriceOfHourse { get; protected set; }
}
