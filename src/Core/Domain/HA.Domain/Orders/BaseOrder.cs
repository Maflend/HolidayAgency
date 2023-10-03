using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Common;

namespace HA.Domain.Orders;

/// <summary>
/// Заказ.
/// </summary>
public abstract class BaseOrder : Entity
{
    /// <summary>
    /// Дата мероприятия.
    /// </summary>
    public DateTime EventDate { get; protected set; }

    /// <summary>
    /// Место проведения.
    /// </summary>
    public string Address { get; protected set; } = null!;

    /// <summary>
    /// Кол-во часов.
    /// </summary>
    public double CountHours { get; protected set; }

    /// <summary>
    /// Кол-во людей.
    /// </summary>
    public virtual int CountPeople { get; protected set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryId { get; protected set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public Category Category { get; protected set; } = null!;

    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public Guid ClientId { get; protected set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public Client Client { get; protected set; } = null!;
}
