namespace HA.Domain.Orders;

/// <summary>
/// Подтвержденный заказ.
/// </summary>
public class ConfirmedOrder : BaseOrder
{
    private decimal _discountPerHour = 0;

    #pragma warning disable CS8618
    private ConfirmedOrder() { }
    #pragma warning restore CS8618

    public ConfirmedOrder(
        UnprocessedOrder unprocessedOrder,
        string eventPlan,
        Dictionary<string, string> peoples,
        decimal DiscountPerHour)
    {
        Category = unprocessedOrder.Category;
        Client = unprocessedOrder.Client;
        Address = unprocessedOrder.Address;
        CountHours = unprocessedOrder.CountHours;
        _discountPerHour = DiscountPerHour;

        EventPlan = eventPlan;
        Peoples = peoples;
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
    public override int CountPeople => Peoples.Count;

    /// <summary>
    /// Скидка в час.
    /// </summary>
    public decimal DiscountPerHour => _discountPerHour;

    public void MakeDiscount(decimal discountPerHour)
    {
        _discountPerHour = discountPerHour;
    }
}
