namespace HA.Application.Common.Exceptions;

internal static class ThrowExceptionExtensions
{
    public static async Task<TEntity> ThrowEntityNotFound<TEntity>(this Task<TEntity?> task, Guid id)
    {
        return await task ?? throw new EntityNotFoundException(typeof(TEntity).Name, id);
    }
}
