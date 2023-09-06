namespace HA.Domain.Entities.Orders;

public class CompleteOrder : BaseOrder
{
    public CompleteOrder(ConfirmOrder confirmOrder, string eventPlan, Dictionary<string, string> peoples)
    {
        Category = confirmOrder.Category;
        PriceList = confirmOrder.PriceList;
        Client = confirmOrder.Client;
        Address = confirmOrder.Address;
        CountHours = confirmOrder.CountHours;

        EventPlan = eventPlan;
        Peoples = peoples;
    }

    public string EventPlan { get; protected set; }
    public Dictionary<string, string> Peoples { get; protected set; }
    public new int CountPeople => Peoples.Count;

    public IReadOnlyCollection<EventFile> Files { get; protected set; }

    //Отзывы.
}