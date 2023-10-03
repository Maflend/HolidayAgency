using FluentResults;
using HA.Application.Common.Persistence;
using HA.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.ConfirmOrder;

/// <summary>
/// Обработчик команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public ConfirmOrderCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<Guid>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var unprocessedOrder = await _applicationDbContext.UnprocessedOrders
            .SingleAsync(order => order.Id == request.UnprocessedOrderId, cancellationToken);

        var confirmedOrder = new ConfirmedOrder(
            unprocessedOrder,
            request.EventPlan,
            request.Peoples,
            request.DiscountPerHour!.Value);

        await _applicationDbContext.ConfirmedOrders.AddAsync(confirmedOrder, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return confirmedOrder.Id;
    }
}
