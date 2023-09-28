using HA.Domain.Common;

namespace HA.Domain.Entities;
public class EventFile : Entity
{
    public Guid Name { get; set; } = Guid.NewGuid();
    public required string OriginalName { get; set; }
    public required string Path { get; set; }

    public Guid CompletedOrderId { get; set; }
}
