using AutoMapper;
using HA.Application.Common.Expressions;
using HA.Application.Common.Models.Pagination;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;
using System.Linq.Expressions;

namespace HA.Application.UseCases.OrdersModeration.GetOrders;

/// <summary>
/// Запрос на получение заказов.
/// </summary>
public record GetOrdersQuery : PagedAndSorted, IRequest<Result<PaginatedResponse<GetOrdersResponse>>>
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
/// Обработчик запроса на получение заказов.
/// </summary>
public class GetOrdersQueryHandler(IDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetOrdersQuery, Result<PaginatedResponse<GetOrdersResponse>>>
{
    public async Task<Result<PaginatedResponse<GetOrdersResponse>>> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Order>()
            .GetPaginatedResponseAsync<Order, GetOrdersResponse>(
                request,
                SearchFilter(request),
                _mapper,
                cancellationToken);
    }

    private static Expression<Func<Order, bool>> SearchFilter(GetOrdersQuery query)
    {
        Expression<Func<Order, bool>> exp = order => true;

        return exp
            .AndIf(query.TheNumberOfHoursIsMoreOrEqThan.HasValue, order => (order.EndDate - order.StartDate).TotalHours >= query.TheNumberOfHoursIsMoreOrEqThan!.Value)
            .AndIf(query.TheNumberOfHoursIsLessOrEqThan.HasValue, order => (order.EndDate - order.StartDate).TotalHours <= query.TheNumberOfHoursIsLessOrEqThan!.Value);
    }
}
