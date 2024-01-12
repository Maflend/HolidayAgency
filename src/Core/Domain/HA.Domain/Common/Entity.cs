namespace HA.Domain.Common;

/// <summary>
/// Сущность.
/// </summary>
public abstract class Entity : IHasId
{
    public Guid Id { get; set; }
}
