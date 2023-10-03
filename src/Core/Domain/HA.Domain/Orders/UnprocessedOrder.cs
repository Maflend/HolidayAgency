using HA.Domain.Categories;
using HA.Domain.Clients;

namespace HA.Domain.Orders;

/// <summary>
/// Необработанный заказ.
/// </summary>
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
