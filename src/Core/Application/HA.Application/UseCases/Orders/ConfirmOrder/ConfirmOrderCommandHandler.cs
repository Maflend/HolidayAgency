using HA.Application.Common.Exceptions;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.UseCases.Orders.ConfirmOrder;

/// <summary>
/// Обработчик команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandHandler(IApplicationDbContext applicationDbContext) 
    : IRequestHandler<ConfirmOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var unprocessedOrder = await applicationDbContext.Set<UnprocessedOrder>()
            .GetByIdAsync(request.UnprocessedOrderId, cancellationToken)
            .ThrowEntityNotFound(request.UnprocessedOrderId);

        var confirmedOrder = new ConfirmedOrder(
            unprocessedOrder,
            request.EventPlan,
            request.Peoples,
            request.DiscountPerHour!.Value);

        await applicationDbContext.Set<ConfirmedOrder>().AddAsync(confirmedOrder, cancellationToken);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return confirmedOrder.Id;
    }
}
