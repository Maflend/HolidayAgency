using FluentResults;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using HA.Domain.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Categories.GetCategoryById;

/// <summary>
/// Обработчик запроса на получение категории по идентификатору.
/// </summary>
public class GetCategoryByIdQyeryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryDto>>
{
    private IApplicationDbContext _dbcontext;

    /// <inheritdoc cref="GetCategoryByIdQyeryHandler"/>
    public GetCategoryByIdQyeryHandler(IApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task<Result<GetCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var existingUnprocessedOrder = 
            await _dbcontext.Categories
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (existingUnprocessedOrder is null)
        {
            return Result.Fail(new NotFoundError("Категория с данным идентификатором не существует."));
        }

        return Map(existingUnprocessedOrder);
    }
    private static GetCategoryDto Map(Category category) => new()
    {
        Id = category.Id,
        PriceOfHourse = category.PriceOfHourse,
        Name = category.Name,
    };
}

