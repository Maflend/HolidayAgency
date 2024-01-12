using AutoMapper;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public record GetUnprocessedOrdersQuery : IRequest<Result<List<GetUnprocessedOrdersResponse>>>;

/// <summary>
/// Обработчик запроса на получение необработанных заказов.
/// </summary>
public class GetUnprocessedOrdersQueryHandler(IApplicationDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetUnprocessedOrdersQuery, Result<List<GetUnprocessedOrdersResponse>>>
{
    public async Task<Result<List<GetUnprocessedOrdersResponse>>> Handle(GetUnprocessedOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<UnprocessedOrder>()
            .GetProjectedListAsync<UnprocessedOrder, GetUnprocessedOrdersResponse>(_mapper, cancellationToken);
    }
}
