using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders;

/// <summary>
/// Запрос на получение необработанных заказов.
/// </summary>
public record GetUnprocessedOrdersQuery : IRequest<Result<List<GetUnprocessedOrdersResponse>>>;

/// <summary>
/// Обработчик запроса на получение необработанных заказов.
/// </summary>
public class GetUnprocessedOrdersQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetUnprocessedOrdersQuery, Result<List<GetUnprocessedOrdersResponse>>>
{
    public async Task<Result<List<GetUnprocessedOrdersResponse>>> Handle(GetUnprocessedOrdersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.UnprocessedOrders
            .Include(x => x.Category)
            .Include(p => p.Client)
            .Select(o => Map(o))
            .ToListAsync(cancellationToken);
    }

    private static GetUnprocessedOrdersResponse Map(UnprocessedOrder order) => new()
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
