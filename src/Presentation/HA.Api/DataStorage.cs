﻿using HA.Domain.Models;
using HA.Domain.Models.Orders;

namespace HA.Api;

public static class DataStorage
{
    public static List<NewOrder> NewOrders = new();
    public static List<ConfirmOrder> ConfirmOrders = new();
    public static List<CompleteOrder> CompleteOrders = new();
    public static List<Client> Clients = new();
    public static List<Category> Categories = new()
    {
        new Category { Id = Guid.Parse("88f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"), Name = "Свадьба" },
        new Category { Id = Guid.Parse("99f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"), Name = "Детский день рождения" }
    };
    public static List<PriceList> PriceLists = new()
    {
        new PriceList 
        {
            Id = Guid.Parse("12f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"),
            CategoryId =  Guid.Parse("88f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"),
            Category = Categories[0],
            IsActive = true,
            PriceOfHourse = 4000M
        },
        new PriceList
        {
            Id = Guid.Parse("11f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"),
            CategoryId =  Guid.Parse("88f8613a-d12c-47e9-9ee7-bb9c1fc7cc38"),
            Category = Categories[0],
            IsActive = true,
            PriceOfHourse = 4000M
        }
    };
}
