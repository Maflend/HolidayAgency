using HA.Domain.Models;

namespace HA.Api;

public static class DataStorage
{
    public static List<Order> Orders = new List<Order>();
    public static List<Client> Clients = new List<Client>();
    public static List<Category> Categories = new List<Category>()
    {
        new Category { Id = Guid.Parse("88f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"), Name = "Свадьба" },
        new Category { Id = Guid.Parse("99f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"), Name = "Детский день рождения" }
    };
}
