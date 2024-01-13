namespace HA.Application.Common.Exceptions;

/// <summary>
/// Исключение: Неверные параметры для пагинации.
/// </summary>
public class InvalidPaginationException : Exception
{
    public InvalidPaginationException() { }
    public InvalidPaginationException(string message) : base(message) { }
    public InvalidPaginationException(string message, Exception inner) : base(message, inner) { }
}