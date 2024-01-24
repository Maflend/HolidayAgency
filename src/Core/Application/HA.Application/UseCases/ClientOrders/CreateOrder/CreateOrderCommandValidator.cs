using FluentValidation;

namespace HA.Application.UseCases.ClientOrders.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator(TimeProvider timeProvider)
    {
        RuleFor(order => order.FirstName)
            .NotEmpty().WithMessage("Имя должно быть указано");

        RuleFor(order => order.LastName)
            .NotEmpty().WithMessage("Фамилия должна быть указан");

        RuleFor(order => order.Phone)
            .NotEmpty().WithMessage("Телефон должен быть указан");

        RuleFor(order => order.EndDate)
            .GreaterThan(order => order.StartDate).WithMessage("Некорректная дата мероприятия");

        RuleFor(order => order.StartDate)
            .ExclusiveBetween(timeProvider.GetUtcNow().Date, timeProvider.GetUtcNow().Date.AddYears(2)).WithMessage("Некорректная дата мероприятия");
    }
}
