﻿using System.Net;

namespace HA.ResultDomain;

public interface IError
{
    string Code { get; }
    string? Description { get; }
    public Dictionary<string, string[]> Reason { get; }
}
