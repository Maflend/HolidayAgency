using AutoMapper;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.OrdersModeration.GetOrderById;

/// <summary>
/// Запрос на получение заказа по идентификатору.
/// </summary>
public record GetOrderByIdQuery(Guid Id) : IRequest<Result<GetOrderByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение заказа по идентификатору.
/// </summary>
public class GetOrderByIdQueryHandler(IDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdResponse>>
{
    public async Task<Result<GetOrderByIdResponse>> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Order>()
            .GetProjectedByIdAsync<Order, GetOrderByIdResponse>(request.Id, _mapper, cancellationToken)
            .ThrowResourceNotFound(typeof(Order), request.Id);
    }
}
