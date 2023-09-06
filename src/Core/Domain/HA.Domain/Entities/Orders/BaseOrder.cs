namespace HA.Domain.Entities.Orders;

public abstract class BaseOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime EventDate { get; protected set; }
    public string Address { get; protected set; }
    public double CountHours { get; protected set; }
    public int CountPeople { get; protected set; }

    public PriceList PriceList { get; protected set; }
    public Category Category { get; protected set; }
    public Client Client { get; protected set; }
}
