using FluentValidation;
using HA.Application.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.CreateOrder;
public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateOrderValidator(IApplicationDbContext applicationDbContext)
    {
        RuleFor(order => order.FirstName).NotEmpty().WithMessage("Имя должно быть указано");
        RuleFor(order => order.LastName).NotEmpty().WithMessage("Фамилия должна быть указано");

        RuleFor(order => order.Address).NotEmpty().WithMessage("Адрес должен быть указан");

        RuleFor(order => order.Phone)
            .NotEmpty().WithMessage("Телефон должен быть указан")
            .Matches(@"^[2-9]\d{2}-\d{3}-\d{4}$").WithMessage("Некорректный номер телефона");

        RuleFor(order => order.CountHourse).GreaterThan(0).WithMessage("Кол-во часов должно быть больше 0");
        RuleFor(order => order.CountPeople).GreaterThan(0).WithMessage("Кол-во людей должно быть больше 0");

        RuleFor(order => order.EventDate)
            .ExclusiveBetween(DateTime.UtcNow, DateTime.UtcNow.AddYears(2)).WithMessage("Некорректная дата мероприятия");
        _applicationDbContext = applicationDbContext;

        RuleFor(order => order.CategoryId).MustAsync(CheckCategoryExistAsync).WithMessage("Категория не найдена");
    }

    private async Task<bool> CheckCategoryExistAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        return category is not null;
    }
}
