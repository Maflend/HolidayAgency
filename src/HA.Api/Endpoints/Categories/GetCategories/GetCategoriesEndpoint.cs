﻿using HA.Api.Extensions;
using HA.Application.UseCases.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Categories.GetCategories;

/// <summary>
/// Конечная точка получения категорий.
/// </summary>
public static class GetCategoriesEndpoint
{
    /// <summary>
    /// Конечная точка получения категорий.
    /// </summary>
    public static void MapGetCategoriesEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("", GetCategoriesAsync)
            .Produces(200, typeof(List<GetCategoriesResponse>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить категории.";
                opts.Description = "Получить категории.";

                return opts;
            });
    }

    internal static Task<IResult> GetCategoriesAsync(ISender sender, [AsParameters] GetCategoriesQuery query)
    {
        return sender.Send(query).ToMinimalApiAsync();
    }
}
