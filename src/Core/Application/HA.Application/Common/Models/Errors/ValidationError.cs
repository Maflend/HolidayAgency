namespace HA.Application.Common.Models.Errors;

public class ValidationError : ErrorBase
{
    public const string DefaultMessage = "Произошла одна или несколько ошибок проверки";

    public ValidationError(string errorKey, string errorValue) : base(DefaultMessage)
    {
        Errors = new Dictionary<string, string[]>()
        {
            { errorKey, new[] { errorValue } }
        };
    }

    public ValidationError(Dictionary<string, string[]> errors) : base(DefaultMessage)
    {
        Errors = errors;
    }

    public Dictionary<string, string[]> Errors { get; } = new();
}
