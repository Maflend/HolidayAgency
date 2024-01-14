namespace HA.Application.Common.Results;

/// <summary>
/// Результат.
/// </summary>
/// <typeparam name="TData">Данные.</typeparam>
public class Result<TData> : IResult
{
    public Result() { }

    internal Result(TData value)
    {
        IsSuccess = true;
        Data = value;
    }

    internal Result(IError error)
    {
        IsSuccess = false;
        Error = error;
    }

    /// <summary>
    /// Данные.
    /// </summary>
    public TData? Data { get; set; }

    public IError? Error { get; set; }
    public bool IsSuccess { get; }

    /// <summary>
    /// Является неудачей.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Создать неудачей результат.
    /// </summary>
    /// <param name="error">Ошибка.</param>
    /// <returns>Неудачный результат.</returns>
    public static Result<TData> Fail(IError error)
        => new(error);

    /// <summary>
    /// Создать успешный результат.
    /// </summary>
    /// <param name="success">Данные.</param>
    /// <returns>Успешный результат.</returns>
    public static Result<TData> Success(TData success)
        => new(success);

    public static implicit operator Result<TData>(TData value)
        => new(value);
}
