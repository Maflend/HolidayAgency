using AutoMapper;
using HA.Application.Common.Expressions;
using HA.Application.Common.Models.Paging;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;
using System.Linq.Expressions;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public record GetUnprocessedOrdersQuery : PagingAndSorting, IRequest<Result<PaginatedResponse<GetUnprocessedOrdersResponse>>>
{
    /// <summary>
    /// Кол-во часов больше или равно чем.
    /// </summary>
    public int? TheNumberOfHoursIsMoreOrEqThan { get; init; }

    /// <summary>
    /// Кол-во часов меньше или равно чем.
    /// </summary>
    public int? TheNumberOfHoursIsLessOrEqThan { get; init; }
}

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
            .GetPaginatedListAsync<UnprocessedOrder, GetUnprocessedOrdersResponse>(
                request,
                SearchFilter(request),
                _mapper,
                cancellationToken);
    }

    private static Expression<Func<UnprocessedOrder, bool>> SearchFilter(GetUnprocessedOrdersQuery query)
    {
        Expression<Func<UnprocessedOrder, bool>> exp = order => true;

        return exp
            .AndIf(query.TheNumberOfHoursIsMoreOrEqThan.HasValue, order => order.CountHours >= query.TheNumberOfHoursIsMoreOrEqThan!.Value)
            .AndIf(query.TheNumberOfHoursIsLessOrEqThan.HasValue, order => order.CountHours <= query.TheNumberOfHoursIsLessOrEqThan!.Value);
    }
}
