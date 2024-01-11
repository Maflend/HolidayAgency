using HA.ResultDomain;

namespace HA.Application.Common.Models.Errors;

public class NotFoundError : IError
{
    public NotFoundError(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
