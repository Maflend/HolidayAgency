using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using HA.Application.Common.Persistence;
using HA.Domain.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Categories.GetCategories;

/// <summary>
/// Обработчик запроса на получение категорий.
/// </summary>
public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<List<GetCategoryListDto>>>
{
    private readonly IApplicationDbContext _dbcontext;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IApplicationDbContext dbContext,IMapper mapper)
    {
        _dbcontext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Result<List<GetCategoryListDto>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken) =>
        await _dbcontext.Categories.ProjectTo<GetCategoryListDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
}
