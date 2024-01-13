using System.Net;

namespace HA.Application.Common.Results;

public interface IError
{
    string Code { get; }
    string? Description { get; }
    public Dictionary<string, string[]> Reason { get; }
}
