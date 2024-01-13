namespace HA.Application.Common.Results;

/// <summary>
/// Информация о ошибке.
/// </summary>
/// <param name="code">Код.</param>
/// <param name="description">Описание.</param>
/// <param name="reason">Причина.</param>
public class Error(
    string code,
    string? description,
    Dictionary<string, string[]> reason) : IError
{
    public Error(string code)
        : this(code, description: null)
    { }

    public Error(string code, string? description)
        : this(code, description, [])
    { }

    public Error(string code, Dictionary<string, string[]> reason)
        : this(code, description: null, reason)
    { }

    public string Code => code;
    public string? Description => description;
    public Dictionary<string, string[]> Reason => reason;
}