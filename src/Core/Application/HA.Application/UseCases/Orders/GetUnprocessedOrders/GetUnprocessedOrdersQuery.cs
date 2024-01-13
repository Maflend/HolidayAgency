using AutoMapper;
using HA.Application.Common.Models.Paging;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public record GetUnprocessedOrdersQuery : PagingAndSorting, IRequest<Result<PaginatedResponse<GetUnprocessedOrdersResponse>>>;

/// <summary>
/// Обработчик запроса на получение необработанных заказов.
/// </summary>
public class GetUnprocessedOrdersQueryHandler(IApplicationDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetUnprocessedOrdersQuery, Result<PaginatedResponse<GetUnprocessedOrdersResponse>>>
{
    public async Task<Result<PaginatedResponse<GetUnprocessedOrdersResponse>>> Handle(
        GetUnprocessedOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<UnprocessedOrder>()
            .GetPaginatedListAsync<UnprocessedOrder, GetUnprocessedOrdersResponse>(request, _mapper, cancellationToken);
    }
}
