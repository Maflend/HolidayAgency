using HA.Domain.Models.Orders;

namespace HA.Domain.Models;
public class EventFile
{
    public Guid Id { get; set; }
    public Guid Name { get; set; } = Guid.NewGuid();
    public required string OriginalName { get; set; }
    public required string Path { get; set; }

    public Guid CompleteOrderId { get; set; }
    public CompleteOrder CompleteOrder { get; set; }
}
