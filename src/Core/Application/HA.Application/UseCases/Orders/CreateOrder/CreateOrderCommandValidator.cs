using FluentValidation;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Orders.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateOrderCommandValidator(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        RuleFor(order => order.FirstName)
            .NotEmpty().WithMessage("Имя должно быть указано");

        RuleFor(order => order.LastName)
            .NotEmpty().WithMessage("Фамилия должна быть указано");

        RuleFor(order => order.Address)
            .NotEmpty().WithMessage("Адрес должен быть указан");

        RuleFor(order => order.Phone)
            .NotEmpty().WithMessage("Телефон должен быть указан")
            .Matches(@"^[2-9]\d{2}-\d{3}-\d{4}$").WithMessage("Некорректный номер телефона");

        RuleFor(order => order.CountHourse)
            .GreaterThan(0).WithMessage("Кол-во часов должно быть больше 0");

        RuleFor(order => order.CountPeople)
            .GreaterThan(0).WithMessage("Кол-во людей должно быть больше 0");

        RuleFor(order => order.EventDate)
            .ExclusiveBetween(DateTime.UtcNow, DateTime.UtcNow.AddYears(2)).WithMessage("Некорректная дата мероприятия");

        RuleFor(order => order.CategoryId)
            .MustAsync(CheckCategoryExistAsync).WithMessage("Категория не найдена");
    }

    private Task<bool> CheckCategoryExistAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.Set<Category>().AnyAsync(c => c.Id == categoryId, cancellationToken);
    }
}
