namespace HA.Api.Endpoints.Orders.Dtos.Requests;

/// <summary>
/// Информация для подтверждения заказа.
/// </summary>
public class ConfirmOrderRequest
{
    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string EventPlan { get; set; }

    /// <summary>
    /// Люди. <br/> 
    /// Key: Фио. <br/>
    /// Value: кем является (друг, брат, коллега...).
    /// </summary>
    public Dictionary<string, string> Peoples { get; set; }

    /// <summary>
    /// Скидка в час.
    /// </summary>
    public decimal DiscountPerHour { get; set; }
}