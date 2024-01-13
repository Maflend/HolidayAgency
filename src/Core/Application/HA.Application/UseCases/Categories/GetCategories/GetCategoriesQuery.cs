using AutoMapper;
using HA.Application.Common.Models.Paging;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using MediatR;

namespace HA.Application.UseCases.Categories.GetCategories;

/// <summary>
/// Запрос на получение всех категорий.
/// </summary>
public record GetCategoriesQuery : PagingAndSorting, IRequest<Result<List<GetCategoriesResponse>>>;

/// <summary>
/// Обработчик запроса на получение категорий.
/// </summary>
public class GetCategoriesQueryHandler(IApplicationDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetCategoriesQuery, Result<List<GetCategoriesResponse>>>
{
    public async Task<Result<List<GetCategoriesResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Category>()
            .GetProjectedListAsync<Category, GetCategoriesResponse>(_mapper, cancellationToken);
    }
}

