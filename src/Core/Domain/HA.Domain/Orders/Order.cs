using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Common;
using HA.Domain.Files;

namespace HA.Domain.Orders;

/// <summary>
/// Заказ.
/// </summary>
public class Order : Entity
{
    private Order() { }

    /// <summary>
    /// Заказ.
    /// </summary>
    public Order(
        Category category,
        Client client,
        DateTime startDate,
        DateTime endDate,
        string? address)
    {
        Category = category;
        Client = client;
        StartDate = startDate;
        EndDate = endDate;
        Address = address;
        Status = OrderStatus.Unprocessed;
    }

    /// <summary>
    /// Статус.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Дата начала мероприятия.
    /// </summary>
    public DateTime StartDate { get; protected set; }

    /// <summary>
    /// Дата окончания мероприятия.
    /// </summary>
    public DateTime EndDate { get; protected set; }

    /// <summary>
    /// Место проведения.
    /// </summary>
    public string? Address { get; protected set; } = null!;

    /// <summary>
    /// Кол-во людей.
    /// </summary>
    public int? NumberOfPeople { get; protected set; }

    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string? EventPlan { get; protected set; }

    /// <summary>
    /// Гости. Key - ФИО. Value - описание.
    /// </summary>
    public Dictionary<string, string>? Guests { get; protected set; } = null!;

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryId { get; protected set; }

    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public Guid ClientId { get; protected set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public Category Category { get; protected set; } = null!;

    /// <summary>
    /// Клиент.
    /// </summary>
    public Client Client { get; protected set; } = null!;

    /// <summary>
    /// Файлы.
    /// </summary>
    public IReadOnlyCollection<EventFile> Files { get; protected set; } = null!;

    public void Confirm()
    {
        Status = OrderStatus.Completed;
    }
}
