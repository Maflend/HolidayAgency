using FluentResults;

namespace HA.Application.Common.Models.Errors;

public class NotFoundError : ErrorBase
{
    public NotFoundError(string message) : base(message)
    {
    }

    public NotFoundError(string message, IError causedBy)
        : base(message, causedBy)
    {
    }
}
