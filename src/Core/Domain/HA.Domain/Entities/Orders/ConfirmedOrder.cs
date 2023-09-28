namespace HA.Domain.Entities.Orders;

public class ConfirmedOrder : BaseOrder
{
    private decimal _discountPerHour = 0;

    private ConfirmedOrder() { }

    public ConfirmedOrder(
        UnprocessedOrder unprocessedOrder,
        string eventPlan,
        Dictionary<string, string> peoples)
    {
        Category = unprocessedOrder.Category;
        Client = unprocessedOrder.Client;
        Address = unprocessedOrder.Address;
        CountHours = unprocessedOrder.CountHours;

        EventPlan = eventPlan;
        Peoples = peoples;
    }

    public string EventPlan { get; protected set; }
    public Dictionary<string, string> Peoples { get; protected set; }
    public new int CountPeople => Peoples.Count;
    public decimal DiscountPerHour => _discountPerHour;

    public void MakeDiscount(decimal discountPerHour)
    {
        _discountPerHour = discountPerHour;
    }
}
