using FluentResults;

namespace HA.Application.Common.Models.Errors;

public abstract class ErrorBase : Error
{
    public ErrorBase(string message) : base(message)
    {
    }

    public ErrorBase(string message, IError causedBy)
        : base(message, causedBy)
    {
    }
}
