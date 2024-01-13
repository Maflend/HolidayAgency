namespace HA.Application.Common.Exceptions;

internal static class ThrowExceptionExtensions
{
    public static async Task<TEntity> ThrowResourceNotFound<TEntity>(this Task<TEntity?> task, Guid id)
    {
        return await task ?? throw new ResourceNotFoundException(typeof(TEntity).Name, id);
    }
}
