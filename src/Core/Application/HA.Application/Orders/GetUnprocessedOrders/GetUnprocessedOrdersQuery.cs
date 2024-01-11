using HA.Application.Orders.GetUnprocessedOrders.Response;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public record GetUnprocessedOrdersQuery : IRequest<Result<List<GetUnprocessedOrderListDto>>>;