namespace HA.Domain.Orders;

/// <summary>
/// Статус заказа.
/// </summary>
public enum OrderStatus
{
    Unprocessed = 0,
    Confirmed = 1,
    Canceled = 2,
    Completed = 3
}