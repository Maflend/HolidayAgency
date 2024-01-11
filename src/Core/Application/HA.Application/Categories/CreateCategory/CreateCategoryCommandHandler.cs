using AutoMapper;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using HA.Domain.Categories;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isNameTaken = await _applicationDbContext.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken);

        if (isNameTaken)
        {
            return Result<Guid>.Fail(new ValidationError("Категория с таким именем уже существует"));
        }

        var category = new Category(request.Name, request.PriceOfHourse);

        await _applicationDbContext.Categories.AddAsync(category, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
