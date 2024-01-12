using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Dependencies.Persistence;
public interface IApplicationDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
