using HA.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Dependencies.Persistence;

/// <summary>
/// Абстракция для доступа к данным.
/// </summary>
public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
