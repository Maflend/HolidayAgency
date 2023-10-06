using AutoMapper;
using FluentResults;
using HA.Application.Common.Persistence;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using HA.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.GetUnprocessedOrders;

/// <summary>
/// Обработчик запроса на получение необработанных заказов.
/// </summary>
public class GetUnprocessedOrdersQueryHandler : IRequestHandler<GetUnprocessedOrdersQuery, Result<List<GetUnprocessedOrderListDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    private readonly IMapper _mapper;
    /// <inheritdoc cref="GetUnprocessedOrdersQueryHandler"/>
    public GetUnprocessedOrdersQueryHandler(IApplicationDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<List<GetUnprocessedOrderListDto>>> Handle(GetUnprocessedOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.UnprocessedOrders
            .Include(x => x.Category)
            .Include(p => p.Client)
            .Select(o => _mapper.Map<UnprocessedOrder,GetUnprocessedOrderListDto>(o))
            .ToListAsync(cancellationToken);
    }

    
}
