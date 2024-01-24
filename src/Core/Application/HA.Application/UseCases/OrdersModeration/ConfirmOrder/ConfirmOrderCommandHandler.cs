using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.OrdersModeration.ConfirmOrder;

/// <summary>
/// Обработчик команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandHandler(IDbContext _applicationDbContext)
    : IRequestHandler<ConfirmOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _applicationDbContext.Set<Order>()
            .GetByIdAsync(request.Id, cancellationToken)
            .ThrowResourceNotFound(typeof(Order), request.Id);

        order.Confirm();
        //var confirmedOrder = new ConfirmedOrder(
        //    order,
        //    request.EventPlan,
        //    request.Peoples,
        //    request.DiscountPerHour!.Value);

        await _applicationDbContext.Set<Order>().AddAsync(order, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
