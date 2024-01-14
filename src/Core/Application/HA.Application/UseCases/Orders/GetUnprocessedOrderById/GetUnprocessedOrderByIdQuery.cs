using AutoMapper;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrderById;

/// <summary>
/// Запрос на получение необработанного заказа по идентификатору.
/// </summary>
public record GetUnprocessedOrderByIdQuery(Guid Id) : IRequest<Result<GetUnprocessedOrderByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение необработанного заказа по идентификатору.
/// </summary>
public class GetUnprocessedOrderByIdQueryHandler(IDbContext _dbContext, IMapper _mapper) 
    : IRequestHandler<GetUnprocessedOrderByIdQuery, Result<GetUnprocessedOrderByIdResponse>>
{
    public async Task<Result<GetUnprocessedOrderByIdResponse>> Handle(
        GetUnprocessedOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<UnprocessedOrder>()
            .GetProjectedByIdAsync<UnprocessedOrder, GetUnprocessedOrderByIdResponse>(request.Id, _mapper, cancellationToken)
            .ThrowResourceNotFound(typeof(UnprocessedOrder), request.Id);
    }
}
