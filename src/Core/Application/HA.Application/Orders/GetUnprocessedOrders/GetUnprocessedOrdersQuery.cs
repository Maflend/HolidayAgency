using FluentResults;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using MediatR;

namespace HA.Application.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public class GetUnprocessedOrdersQuery : IRequest<Result<List<GetOrderUnprocessedDto>>> { }
