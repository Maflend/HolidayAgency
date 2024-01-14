namespace HA.Application.Common.Exceptions;

internal static class ThrowExceptionExtensions
{
    /// <summary>
    /// Выбросить исключение <see cref="ResourceNotFoundException"/>, если результат выполнения <see cref="Task{T?}"/> <see langword="is"/> <see langword="null"/>.
    /// </summary>
    /// <typeparam name="TResult">Тип результата выполнения задачи.</typeparam>
    /// <param name="task">Задача.</param>
    /// <param name="resourceType">Тип ресурса.</param>
    /// <param name="id">Идентификатор.</param>
    public static async Task<TResult> ThrowResourceNotFound<TResult>(this Task<TResult?> task, Type resourceType, Guid id)
        => await task.ThrowResourceNotFound(resourceType.Name, id);

    /// <summary>
    /// Выбросить исключение <see cref="ResourceNotFoundException"/>, если результат выполнения <see cref="Task{T?}"/> <see langword="is"/> <see langword="null"/>.
    /// </summary>
    /// <typeparam name="TResult">Тип результата выполнения задачи.</typeparam>
    /// <param name="task">Задача.</param>
    /// <param name="resourceName">Имя ресурса.</param>
    /// <param name="id">Идентификатор.</param>
    public static async Task<TResult> ThrowResourceNotFound<TResult>(this Task<TResult?> task, string resourceName, Guid id)
        => await task ?? throw new ResourceNotFoundException(resourceName, id);
}
