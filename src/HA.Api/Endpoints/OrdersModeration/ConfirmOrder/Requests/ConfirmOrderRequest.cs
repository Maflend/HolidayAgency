namespace HA.Api.Endpoints.OrdersModeration.ConfirmOrder.Requests;

/// <summary>
/// Информация для подтверждения заказа.
/// </summary>
public class ConfirmOrderRequest
{
    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string EventPlan { get; set; } = null!;

    /// <summary>
    /// Люди. <br/> 
    /// Key: Фио. <br/>
    /// Value: кем является (друг, брат, коллега...).
    /// </summary>
    public Dictionary<string, string> Peoples { get; set; } = null!;

    /// <summary>
    /// Скидка в час.
    /// </summary>
    public decimal DiscountPerHour { get; set; }
}