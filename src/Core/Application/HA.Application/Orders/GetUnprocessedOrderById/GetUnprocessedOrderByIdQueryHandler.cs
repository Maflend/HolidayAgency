using AutoMapper;
using FluentResults;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using HA.Application.Orders.GetUnprocessedOrderById.Responce;
using HA.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.GetUnprocessedOrderById;

/// <summary>
/// Обработчик запроса на получение необработанного заказа по идентификатору.
/// </summary>
public class GetUnprocessedOrderByIdQueryHandler : IRequestHandler<GetUnprocessedOrderByIdQuery, Result<GetUnprocessedOrderByIdDto>>
{
    private IApplicationDbContext _dbcontext;

    private IMapper _mapper;

    /// <inheritdoc cref="GetUnprocessedOrdersQueryHandler"/>
    public GetUnprocessedOrderByIdQueryHandler(IApplicationDbContext dbContext,IMapper mapper)
    {
        _dbcontext = dbContext;
        _mapper = mapper;
    }


    public async Task<Result<GetUnprocessedOrderByIdDto>> Handle(GetUnprocessedOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var existingUnprocessedOrder = await _dbcontext.UnprocessedOrders
            .Include(x => x.Client)
            .Include(x => x.Category)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (existingUnprocessedOrder is null)
        {
            return Result.Fail(new NotFoundError("Необработанный заказ не существует."));
        }

        return _mapper.Map<UnprocessedOrder,GetUnprocessedOrderByIdDto>(existingUnprocessedOrder);
    }
}

