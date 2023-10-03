namespace HA.Application.Orders.GetUnprocessedOrders.Response;

/// <summary>
/// Информация о необработанном заказе.
/// </summary>
public class GetUnprocessedOrderListDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime EventDate { get; set; }

    /// <summary>
    /// Адрес проведения.
    /// </summary>
    public string Address { get; set; }

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
    public ClientInfoDto Client { get; set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public string CategoryName { get; set; }
}
