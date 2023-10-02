using FluentResults;
using HA.Application.Common.Persistence;
using HA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Categories.GetCategories;

/// <summary>
/// Обработчик запроса на получение категорий.
/// </summary>
public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<List<GetCategoriesQueryDto>>>
{
    private readonly IApplicationDbContext _dbcontext;

    public GetCategoriesQueryHandler(IApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    
    public async Task<Result<List<GetCategoriesQueryDto>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken) =>
        await _dbcontext.Categories
        .Select(o => Map(o))
        .ToListAsync(cancellationToken);

    private GetCategoriesQueryDto Map(Category category) => new()
    {
        Id = category.Id,
        Name = category.Name,
        PriceOfHourse = category.PriceOfHourse,
    };
}

