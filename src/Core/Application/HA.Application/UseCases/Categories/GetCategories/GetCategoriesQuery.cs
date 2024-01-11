using HA.Application.Common.Models.Paging;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Categories.GetCategories;

/// <summary>
/// Запрос на получение всех категорий.
/// </summary>
public record GetCategoriesQuery : PagingAndSorting, IRequest<Result<List<GetCategoryListDto>>>;

/// <summary>
/// Обработчик запроса на получение категорий.
/// </summary>
public class GetCategoriesQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetCategoriesQuery, Result<List<GetCategoryListDto>>>
{
    public async Task<Result<List<GetCategoryListDto>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await dbContext.Categories
            .Select(o => Map(o))
            .ToListAsync(cancellationToken);
    }

    private static GetCategoryListDto Map(Category category) => new()
    {
        Id = category.Id,
        Name = category.Name,
        PriceOfHourse = category.PriceOfHourse,
    };
}

