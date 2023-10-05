using FluentResults.Extensions.AspNetCore;
using HA.Application.Categories.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Categories.GetCategoryById;

/// <summary>
/// Конечная точка получения категорий.
/// </summary>
public static class GetCategoryByIdEndpoint
{
    /// <summary>
    /// Конечная точка получения категорий.
    /// </summary>
    public static void MapGetCategoryByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}", GetCategoryByIdAsync)
            .Produces(200, typeof(GetCategoryDto))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить категорию по идентификатору.";
                opts.Description = "Получить категорию по идентификатору.";

                return opts;
            });
    }
    internal static Task<ActionResult> GetCategoryByIdAsync(
       [FromRoute] Guid id,
       ISender sender)
    {
        return sender.Send(new GetCategoryByIdQuery(id)).ToActionResult();
    }
}
