using HA.Domain.Entities.Orders;

namespace HA.Domain.Entities;
public class EventFile
{
    public Guid Id { get; set; }
    public Guid Name { get; set; } = Guid.NewGuid();
    public required string OriginalName { get; set; }
    public required string Path { get; set; }

    public Guid CompleteOrderId { get; set; }
    public CompleteOrder CompleteOrder { get; set; }
}
