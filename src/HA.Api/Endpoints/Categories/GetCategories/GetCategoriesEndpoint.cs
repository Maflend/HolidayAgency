using HA.Application.Common.Models.Pagination;
using HA.Application.UseCases.Categories.GetCategories;

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
            .Produces(StatusCodes.Status200OK, typeof(Result<PaginatedResponse<GetCategoriesResponse>>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить категории.";
                opts.Description = "Получить категории.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetCategoriesAsync(ISender sender, [AsParameters] GetCategoriesQuery query)
    {
        return sender.Send(query).ToMinimalApiAsync();
    }
}
