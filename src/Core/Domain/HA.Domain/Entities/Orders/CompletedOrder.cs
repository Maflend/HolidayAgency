namespace HA.Domain.Entities.Orders;

public class CompletedOrder : BaseOrder
{
    private CompletedOrder() { }

    public CompletedOrder(
        ConfirmedOrder confirmedOrder,
        string eventPlan,
        Dictionary<string, string> peoples)
    {
        Category = confirmedOrder.Category;
        Client = confirmedOrder.Client;
        Address = confirmedOrder.Address;
        CountHours = confirmedOrder.CountHours;

        EventPlan = eventPlan;
        Peoples = peoples;
    }

    public string EventPlan { get; protected set; }
    public Dictionary<string, string> Peoples { get; protected set; }
    public new int CountPeople => Peoples.Count;

    public IReadOnlyCollection<EventFile> Files { get; protected set; } = new List<EventFile>();

    //TODO: Отзывы.
}