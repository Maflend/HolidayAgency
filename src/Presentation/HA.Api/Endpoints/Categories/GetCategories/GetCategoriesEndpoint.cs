using FluentResults.Extensions.AspNetCore;
using HA.Application.Categories.GetCategories;
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
            .Produces(200, typeof(List<GetCategoryListDto>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить категории.";
                opts.Description = "Получить категории.";

                return opts;
            });
    }

    internal static Task<ActionResult> GetCategoriesAsync(
        ISender sender)
    {
        return sender.Send(new GetCategoriesQuery()).ToActionResult();
    }
}
