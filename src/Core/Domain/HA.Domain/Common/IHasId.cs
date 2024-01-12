namespace HA.Domain.Common;

/// <summary>
/// Имеет идентификатор.
/// </summary>
public interface IHasId
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
}
