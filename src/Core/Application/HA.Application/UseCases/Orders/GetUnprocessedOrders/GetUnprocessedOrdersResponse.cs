using HA.Application.UseCases.Orders.GetUnprocessedOrders.Responses;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders;

/// <summary>
/// Информация о необработанном заказе.
/// </summary>
public class GetUnprocessedOrdersResponse
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime EventDate { get; set; }

    /// <summary>
    /// Адрес проведения.
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Количество часов.
    /// </summary>
    public double CountHours { get; set; }

    /// <summary>
    /// Количество людей.
    /// </summary>
    public int CountPeople { get; set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public GetUnprocessedOrdersClientInfoDto Client { get; set; } = null!;

    /// <summary>
    /// Категория.
    /// </summary>
    public string CategoryName { get; set; } = null!;
}
