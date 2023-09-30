using HA.Domain.Common;

namespace HA.Domain.Entities;

/// <summary>
/// Категория.
/// </summary>
public class Category : Entity
{
    private Category() { }

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
