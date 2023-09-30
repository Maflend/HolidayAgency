namespace HA.Domain.Entities.Orders;

/// <summary>
/// Выполненный заказ.
/// </summary>
public class CompletedOrder : BaseOrder
{
    private CompletedOrder() { }

    public CompletedOrder(
        ConfirmedOrder confirmedOrder)
    {
        Category = confirmedOrder.Category;
        Client = confirmedOrder.Client;
        Address = confirmedOrder.Address;
        CountHours = confirmedOrder.CountHours;
        Peoples = confirmedOrder.Peoples;
        EventPlan = confirmedOrder.EventPlan; 
    }

    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string EventPlan { get; protected set; }

    /// <summary>
    /// Люди. <br/>
    /// Key: Фио. <br/>
    /// Value: кем является (друг, брат, коллега...).
    /// </summary>
    public Dictionary<string, string> Peoples { get; protected set; }
    public new int CountPeople => Peoples.Count;

    /// <summary>
    /// Файлы.
    /// </summary>
    public IReadOnlyCollection<EventFile> Files { get; protected set; } = new List<EventFile>();

    //TODO: Отзывы.
}