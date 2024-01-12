using FluentValidation;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Orders.ConfirmOrder;

/// <summary>
/// Валидатор команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public ConfirmOrderCommandValidator(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        RuleFor(order => order.UnprocessedOrderId)
            .MustAsync((unprocessedOrderId, ct) =>
            {
                return _applicationDbContext.Set<UnprocessedOrder>().AnyAsync(o => o.Id == unprocessedOrderId, ct);
            }).WithMessage("Необработанного заказа не существует");

        //TODO: А что если категорией является детская елка. Там не известны имена всех детей.
        RuleFor(order => order.Peoples)
            .NotNull().NotEmpty().WithMessage("Люди мероприятия должны быть указаны");
    }
}
