using HA.Application.Common.Results;
using MediatR;

namespace HA.Application.UseCases.OrdersModeration.ConfirmOrder;

/// <summary>
/// Команда подтверждения заказа.
/// </summary>
/// <param name="Id">Идентификатор заказа.</param>
/// <param name="EventPlan">План мероприятия.</param>
/// <param name="Peoples">
/// Люди. <br/> 
/// Key: Фио. <br/>
/// Value: кем является (друг, брат, коллега...).
/// </param>
/// <param name="DiscountPerHour">Скидка в час.</param>
public record ConfirmOrderCommand(
    Guid Id,
    string EventPlan,
    Dictionary<string, string> Peoples,
    decimal? DiscountPerHour) : IRequest<Result<Guid>>;
