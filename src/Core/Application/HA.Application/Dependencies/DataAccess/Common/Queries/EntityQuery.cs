using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Dependencies.DataAccess.Common.Queries;

internal static class EntityQuery
{
    public static Task<TEntity?> GetByIdAsync<TEntity>(
        this IQueryable<TEntity> entities,
        Guid id,
        CancellationToken cancellationToken) where TEntity : Entity
    {
        return entities.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
