using HA.Domain.Models;

namespace HA.Api;

public static class DataStorage
{
    public static List<Order> Orders = new List<Order>();
    public static List<Category> Categories = new List<Category>()
    {
        new Category { Id = Guid.NewGuid(), Name = "Свадьба" },
        new Category { Id = Guid.NewGuid(), Name = "Детский день рождения" }
    };
}
