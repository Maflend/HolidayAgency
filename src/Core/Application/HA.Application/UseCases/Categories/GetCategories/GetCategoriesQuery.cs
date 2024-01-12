using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Models.Paging;
using HA.Application.Dependencies.Persistence;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        return await _dbContext.Categories
            .ProjectTo<GetCategoriesResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

