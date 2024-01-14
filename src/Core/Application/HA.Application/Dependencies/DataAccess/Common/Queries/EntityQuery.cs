using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Mappings;
using HA.Application.Common.Models.Pagination;
using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace HA.Application.Dependencies.DataAccess.Common.Queries;

internal static class EntityQuery
{
    /// <summary>
    /// Получить сущность по идентификатору.
    /// </summary>
    public static Task<TEntity?> GetByIdAsync<TEntity>(
        this IQueryable<TEntity> entities,
        Guid id,
        CancellationToken cancellationToken = default) 
        where TEntity : Entity
    {
        return entities.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получить ProjectTo сущность по идентификатору.
    /// </summary>
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

    /// <summary>
    /// Получить ProjectTo сущности.
    /// </summary>
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

    /// <summary>
    /// Получить <see cref="PaginatedResponse{TDto}"/>.
    /// </summary>
    /// <exception cref="InvalidPaginationException">Неверные параметры для постраничного получения.</exception>
    public static async Task<PaginatedResponse<TDto>> GetPaginatedResponseAsync<TEntity, TDto>(
        this IQueryable<TEntity> source,
        PagedAndSorted options,
        Expression<Func<TEntity, bool>>? searchFilter,
        IMapper mapper,
        CancellationToken cancellationToken = default)
        where TEntity : Entity
        where TDto : IMapFrom<TEntity>
    {
        var totalCount = source.Count();
        var totalPages = totalCount == 0 ? 
            0 : 
            (int)Math.Ceiling(totalCount / (double)options.PageSize);

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
                throw new InvalidPaginationException("Неверные параметры для постраничного получения", ex);
            }
        }

        if (searchFilter is not null)
        {
            query = query.Where(searchFilter);
        }

        var list = await query.GetProjectedListAsync<TEntity, TDto>(mapper, cancellationToken: cancellationToken);

        return new PaginatedResponse<TDto>(options.PageNumber, options.PageSize, totalCount, totalPages, list);
    }
}
