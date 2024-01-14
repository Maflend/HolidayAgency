using AutoMapper;
using HA.Application.Common.Expressions;
using HA.Application.Common.Models.Pagination;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using MediatR;
using System.Linq.Expressions;

namespace HA.Application.UseCases.Categories.GetCategories;

/// <summary>
/// Запрос на получение всех категорий.
/// </summary>
public record GetCategoriesQuery : PagedAndSorted, IRequest<Result<PaginatedResponse<GetCategoriesResponse>>>
{
    /// <summary>
    /// Название.
    /// </summary>
    public string? Name { get; init; }
}

/// <summary>
/// Обработчик запроса на получение категорий.
/// </summary>
public class GetCategoriesQueryHandler(IDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetCategoriesQuery, Result<PaginatedResponse<GetCategoriesResponse>>>
{
    public async Task<Result<PaginatedResponse<GetCategoriesResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Category>()
            .GetPaginatedResponseAsync<Category, GetCategoriesResponse>(request, SearchFilter(request), _mapper, cancellationToken);
    }

    private static Expression<Func<Category, bool>> SearchFilter(GetCategoriesQuery query)
    {
        Expression<Func<Category, bool>> exp = order => true;

        return exp
            .AndIf(!string.IsNullOrWhiteSpace(query.Name), order => order.Name.ToUpper().StartsWith(query.Name!.ToUpper()));
    }
}
