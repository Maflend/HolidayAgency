using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Models.Errors;
using HA.Application.Dependencies.Persistence;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrderById;

/// <summary>
/// Запрос на получение необработанного заказа по идентификатору.
/// </summary>
public record GetUnprocessedOrderByIdQuery(Guid Id) : IRequest<Result<GetUnprocessedOrderByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение необработанного заказа по идентификатору.
/// </summary>
public class GetUnprocessedOrderByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) 
    : IRequestHandler<GetUnprocessedOrderByIdQuery, Result<GetUnprocessedOrderByIdResponse>>
{
    public async Task<Result<GetUnprocessedOrderByIdResponse>> Handle(
        GetUnprocessedOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var existingUnprocessedOrder = await dbContext.UnprocessedOrders
            .ProjectTo<GetUnprocessedOrderByIdResponse>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
            .ThrowEntityNotFound(request.Id);

        if (existingUnprocessedOrder is null)
        {
            return Result<GetUnprocessedOrderByIdResponse>.Fail(new NotFoundError("Необработанный заказ не существует."));
        }

        return existingUnprocessedOrder;
    }
}
