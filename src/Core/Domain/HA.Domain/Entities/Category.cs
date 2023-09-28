using HA.Domain.Common;

namespace HA.Domain.Entities;

public class Category : Entity
{
    private Category() { }

    public Category(string name, decimal priceOfHourse)
    {
        Name = name;
        PriceOfHourse = priceOfHourse;
    }

    public string Name { get; protected set; }
    public decimal PriceOfHourse { get; protected set; }
}
