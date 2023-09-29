using HA.Domain.Entities;
using MediatR;

namespace HA.Application.Orders.GetUnprocessedOrders;

public class GetUnprocessedOrdersQuery : IRequest<IList<GetOrderUnprocessedDto>>
{

}
