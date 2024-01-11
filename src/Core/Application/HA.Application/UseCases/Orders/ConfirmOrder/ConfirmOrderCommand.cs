using HA.ResultDomain;
using MediatR;

namespace HA.Application.UseCases.Orders.ConfirmOrder;

/// <summary>
/// Команда подтверждения заказа.
/// </summary>
/// <param name="UnprocessedOrderId">Идентификатор заказа.</param>
/// <param name="EventPlan">План мероприятия.</param>
/// <param name="Peoples">
/// Люди. <br/> 
/// Key: Фио. <br/>
/// Value: кем является (друг, брат, коллега...).
/// </param>
/// <param name="DiscountPerHour">Скидка в час.</param>
public record ConfirmOrderCommand(
    Guid UnprocessedOrderId,
    string EventPlan,
    Dictionary<string, string> Peoples,
    decimal? DiscountPerHour) : IRequest<Result<Guid>>;
