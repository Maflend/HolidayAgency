using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Mapping;
using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;

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
}
