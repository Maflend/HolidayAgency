using MediatR;

namespace HA.Application.Orders.GetUnprocessedOrders;

public class GetUnprocessedOrdersQueryHandler : IRequestHandler<GetUnprocessedOrdersQuery, IList<GetOrderUnprocessedDto>>
{
    public Task<IList<GetOrderUnprocessedDto>> Handle(GetUnprocessedOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
