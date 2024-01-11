namespace HA.Application.Common.Exceptions;

/// <summary>
/// Исключение: Сущность не найдена.
/// </summary>
internal class EntityNotFoundException : Exception, IUnexpectedException
{
    public const string ObjectWithIdMessagePattern = "Объект {0} с Id = {1} не найден";

    public EntityNotFoundException(string objectName, Guid id) 
        : base(string.Format(ObjectWithIdMessagePattern, objectName, id)) { }

    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
}
