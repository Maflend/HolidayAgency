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

    /// <inheritdoc cref="GetUnprocessedOrderByIdQueryHandler"/>
    public GetUnprocessedOrderByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
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

        return Map(existingUnprocessedOrder);
    }

    private static GetUnprocessedOrderByIdDto Map(UnprocessedOrder order) => new()
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

