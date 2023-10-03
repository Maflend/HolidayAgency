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

    /// <inheritdoc cref="GetUnprocessedOrdersQueryHandler"/>
    public GetUnprocessedOrdersQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<GetUnprocessedOrderListDto>>> Handle(GetUnprocessedOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.UnprocessedOrders
            .Include(x => x.Category)
            .Include(p => p.Client)
            .Select(o => Map(o))
            .ToListAsync(cancellationToken);
    }

    private static GetUnprocessedOrderListDto Map(UnprocessedOrder order) => new()
    {
        Id = order.Id,
        CategoryName = order.Category.Name,
        EventDate = order.EventDate,
        CountPeople = order.CountPeople,
        CountHours = order.CountHours,
        Address = order.Address,
        Client = new()
        {
            Id = order.Client.Id,
            Surname = order.Client.Surname,
            Name = order.Client.Name,
            Patronymic = order.Client.Patronymic,
            Phone = order.Client.Phone
        }
    };
}
