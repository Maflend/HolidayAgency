using AutoMapper;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Models.Errors;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrderById;

/// <summary>
/// Запрос на получение необработанного заказа по идентификатору.
/// </summary>
public record GetUnprocessedOrderByIdQuery(Guid Id) : IRequest<Result<GetUnprocessedOrderByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение необработанного заказа по идентификатору.
/// </summary>
public class GetUnprocessedOrderByIdQueryHandler(IApplicationDbContext _dbContext, IMapper _mapper) 
    : IRequestHandler<GetUnprocessedOrderByIdQuery, Result<GetUnprocessedOrderByIdResponse>>
{
    public async Task<Result<GetUnprocessedOrderByIdResponse>> Handle(
        GetUnprocessedOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var existingUnprocessedOrder = await _dbContext.Set<UnprocessedOrder>()
            .GetProjectedByIdAsync<UnprocessedOrder, GetUnprocessedOrderByIdResponse>(request.Id, _mapper, cancellationToken)
            .ThrowEntityNotFound(request.Id);

        if (existingUnprocessedOrder is null)
        {
            return Result<GetUnprocessedOrderByIdResponse>.Fail(new NotFoundError("Необработанный заказ не существует."));
        }

        return existingUnprocessedOrder;
    }
}
