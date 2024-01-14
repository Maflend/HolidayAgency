namespace HA.Application.Common.Results;

/// <summary>
/// Результат.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Является успешным.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Ошибка.
    /// </summary>
    public IError? Error { get; set; }
}
