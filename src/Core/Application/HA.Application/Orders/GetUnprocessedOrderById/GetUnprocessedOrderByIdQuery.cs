using FluentResults;
using HA.Application.Orders.GetUnprocessedOrderById.Responce;
using MediatR;

namespace HA.Application.Orders.GetUnprocessedOrderById;

/// <summary>
/// Запрос на получение необработанных заказов по идентификатору.
/// </summary>
public record GetUnprocessedOrderByIdQuery(Guid Id) : IRequest<Result<GetUnprocessedOrderByIdListDto>>;
