namespace HA.Domain.Entities.Orders;

public class ConfirmOrder : BaseOrder
{
    public ConfirmOrder(NewOrder newOrder, string eventPlan, Dictionary<string, string> peoples)
    {
        Category = newOrder.Category;
        PriceList = newOrder.PriceList;
        Client = newOrder.Client;
        Address = newOrder.Address;
        CountHours = newOrder.CountHours;

        EventPlan = eventPlan;
        Peoples = peoples;
    }

    public string EventPlan { get; protected set; }
    public Dictionary<string, string> Peoples { get; protected set; }
    public new int CountPeople => Peoples.Count;
}
