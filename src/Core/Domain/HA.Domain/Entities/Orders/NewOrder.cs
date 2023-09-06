namespace HA.Domain.Entities.Orders;

public class NewOrder : BaseOrder
{
    public NewOrder(
        Category category,
        PriceList priceList,
        Client client,
        DateTime eventDate,
        string address,
        double countHours,
        int countPeople)
    {
        Category = category;
        PriceList = priceList;
        Client = client;
        EventDate = eventDate;
        Address = address;
        CountHours = countHours;
        CountPeople = countPeople;
    }
}
