using FluentValidation;

namespace HA.Application.Categories.CreateCategory;
public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty().WithMessage("Имя должно быть указано");
        RuleFor(category => category.PriceOfHourse).GreaterThan(0).WithMessage("Цена за час должна быть больше 0");
    }
}
