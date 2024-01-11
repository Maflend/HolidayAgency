using HA.Domain.Common;

namespace HA.Application.Common.Exceptions;
internal static class ThrowExceptionExtensions
{
    public static async Task<TEntity> ThrowEntityNotFound<TEntity>(this Task<TEntity?> task, Guid id)
        where TEntity : Entity
    {
        return await task ?? throw new EntityNotFoundException(typeof(TEntity).Name, id);
    }
}
