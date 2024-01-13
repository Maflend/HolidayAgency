using HA.Application.Common.Results;
using HA.Application.UseCases.Categories.GetCategories;
using MediatR;

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

    internal static Task<Result<List<GetCategoriesResponse>>> GetCategoriesAsync(
        ISender sender)
    {
        return sender.Send(new GetCategoriesQuery());
    }
}
