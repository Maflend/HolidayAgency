using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Mapping;
using HA.Application.Common.Models.Paging;
using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HA.Application.Dependencies.DataAccess.Common.Queries;

internal static class EntityQuery
{
    public static Task<TEntity?> GetByIdAsync<TEntity>(
        this IQueryable<TEntity> entities,
        Guid id,
        CancellationToken cancellationToken = default) 
        where TEntity : Entity
    {
        return entities.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public static Task<TDto?> GetProjectedByIdAsync<TEntity, TDto>(
        this IQueryable<TEntity> entities,
        Guid id,
        IMapper mapper,
        CancellationToken cancellationToken = default)
        where TEntity : Entity
        where TDto : IMapFrom<TEntity>, IHasId
    {
        return entities
            .ProjectTo<TDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public static Task<List<TDto>> GetProjectedListAsync<TEntity, TDto>(
        this IQueryable<TEntity> entities,
        IMapper mapper,
        CancellationToken cancellationToken = default)
        where TEntity : Entity
        where TDto : IMapFrom<TEntity>
    {
        return entities
            .ProjectTo<TDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public static async Task<PaginatedResponse<TDto>> GetPaginatedListAsync<TEntity, TDto>(
        this IQueryable<TEntity> source,
        PagingAndSorting options,
        IMapper mapper,
        CancellationToken cancellationToken = default)
        where TEntity : Entity
        where TDto : IMapFrom<TEntity>
    {
        var totalCount = source.Count();
        var totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)options.PageSize);

        var query = source
            .Skip((options.PageNumber - 1) * options.PageSize)
            .Take(options.PageSize);

        if (!string.IsNullOrWhiteSpace(options.Sorting))
        {
            try
            {
                query = query.OrderBy(options.Sorting);
            }
            catch (Exception ex)
            {
                throw new InvalidPaginationException(ex.Message, ex);
            }
        }

        var list = await query.GetProjectedListAsync<TEntity, TDto>(mapper, cancellationToken: cancellationToken);

        return new PaginatedResponse<TDto>(options.PageNumber, options.PageSize, totalCount, totalPages, list);
    }
}
