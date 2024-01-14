namespace HA.Application.Common.Exceptions;

/// <summary>
/// Исключение: Ресурс не найден.
/// </summary>
public class ResourceNotFoundException : Exception
{
    public const string ResourceNotFoundMessagePattern = "Ресурс {0} с Id = {1} не найден";

    public ResourceNotFoundException(string resource, Guid id)
        : base(string.Format(ResourceNotFoundMessagePattern, resource, id)) { }

    public ResourceNotFoundException(string message) : base(message) { }

    public ResourceNotFoundException(string message, Exception inner) : base(message, inner) { }
}
