using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.Orders.ConfirmOrder;

/// <summary>
/// Обработчик команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandHandler(IApplicationDbContext _applicationDbContext) 
    : IRequestHandler<ConfirmOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var unprocessedOrder = await _applicationDbContext.Set<UnprocessedOrder>()
            .GetByIdAsync(request.UnprocessedOrderId, cancellationToken)
            .ThrowResourceNotFound(request.UnprocessedOrderId);

        var confirmedOrder = new ConfirmedOrder(
            unprocessedOrder,
            request.EventPlan,
            request.Peoples,
            request.DiscountPerHour!.Value);

        await _applicationDbContext.Set<ConfirmedOrder>().AddAsync(confirmedOrder, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return confirmedOrder.Id;
    }
}
