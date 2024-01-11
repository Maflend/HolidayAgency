using HA.ResultDomain;

namespace HA.Application.Common.Models.Errors;

public class ValidationError : IError
{
    public ValidationError(string message)
    {
        Message = message;
    }

    public ValidationError(Dictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public string Message { get; } = string.Empty;

    public Dictionary<string, string[]> Errors { get; set; } = [];
}