using FluentValidation;

namespace HA.Application.UseCases.Orders.ConfirmOrder;

/// <summary>
/// Валидатор команды подтверждения заказа.
/// </summary>
public class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
{
    public ConfirmOrderCommandValidator()
    {
        //TODO: А что если категорией является детская елка. Там не известны имена всех детей.
        RuleFor(order => order.Peoples)
            .NotNull().NotEmpty().WithMessage("Люди мероприятия должны быть указаны");
    }
}
