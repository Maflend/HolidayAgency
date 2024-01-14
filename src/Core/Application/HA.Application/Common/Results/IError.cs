namespace HA.Application.Common.Results;

/// <summary>
/// Ошибка.
/// </summary>
public interface IError
{
    /// <summary>
    /// Код.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// Описание.
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// Причина.
    /// </summary>
    public Dictionary<string, string[]> Reason { get; }
}
