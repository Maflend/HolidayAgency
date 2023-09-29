﻿namespace HA.Domain.Entities.Orders;

public class UnprocessedOrder : BaseOrder
{
    private UnprocessedOrder() { }

    public UnprocessedOrder(
        Category category,
        Client client,
        DateTime eventDate,
        string address,
        double countHours,
        int countPeople)
    {
        Category = category;
        Client = client;
        EventDate = eventDate;
        Address = address;
        CountHours = countHours;
        CountPeople = countPeople;
    }
}