using FluentResults;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using HA.Application.Orders.GetUnprocessedOrderById.Responce;
using HA.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.GetUnprocessedOrderById;

/// <summary>
/// Обработчик запроса на получение необработанных заказов по идентификатору.
/// </summary>
public class GetUnprocessedOrderByIdQueryHandler : IRequestHandler<GetUnprocessedOrderByIdQuery, Result<GetUnprocessedOrderByIdListDto>>
{
    private IApplicationDbContext _dbcontext;

    /// <inheritdoc cref="GetUnprocessedOrdersQueryHandler"/>
    public GetUnprocessedOrderByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }


    public async Task<Result<GetUnprocessedOrderByIdListDto>> Handle(GetUnprocessedOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (!_dbcontext.UnprocessedOrders.Any(x => x.Id == request.Id))
        {
            return Result.Fail(new NotFoundError("Необработанный заказ не существует."));
        }

        return await _dbcontext.UnprocessedOrders
            .Include(x => x.Client)
            .Include(x => x.Category)
            .Where(x => x.Id == request.Id)
            .Select(x => Map(x))
            .FirstAsync();
    }
    private static GetUnprocessedOrderByIdListDto Map(UnprocessedOrder order) => new()
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

