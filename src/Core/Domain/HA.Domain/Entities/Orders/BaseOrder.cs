using HA.Domain.Common;

namespace HA.Domain.Entities.Orders;

public abstract class BaseOrder : Entity
{
    public DateTime EventDate { get; protected set; }
    public string Address { get; protected set; } = null!;
    public double CountHours { get; protected set; }
    public int CountPeople { get; protected set; }

    public Guid CategoryId { get; protected set; }
    public Category Category { get; protected set; } = null!;
    public Guid ClientId { get; protected set; }
    public Client Client { get; protected set; } = null!;
}
