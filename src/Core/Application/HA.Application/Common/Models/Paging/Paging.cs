﻿using System.ComponentModel;

namespace HA.Application.Common.Models.Paging;

/// <summary>
/// Пагинация.
/// </summary>
public abstract record Paging : IPaged
{
    [DefaultValue(1)]
    public int PageNumber { get; init; } = 1;

    [DefaultValue(10)]
    public int PageSize { get; init; } = 10;
}