using HA.Application.Categories.CreateCategory;
using HA.ResultAsp.MinimalApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace HA.Api.Endpoints.Categories.CreateCategory;

/// <summary>
/// Конечная точка создания категории.
/// </summary>
public static class CreateCategoryEndpoint
{
    /// <summary>
    /// Конечная точка создания категории.
    /// </summary>
    public static void MapCreateCategoryEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("", CreateCategoryAsync)
            .Produces(200, typeof(Guid))
            .Produces(400, typeof(ValidationProblemDetails))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Создание категории.";
                opts.Description = "Создание категории.";
                opts.Parameters = new List<OpenApiParameter>()
                {
                    new OpenApiParameter()
                    {
                        Name = "createCategoryCommand",
                        Description = "Информация для создания категории.",
                        Required = true
                    }
                };

                return opts;
            });
    }

    internal static Task<IResult> CreateCategoryAsync(
        ISender sender,
        [FromBody] CreateCategoryCommand createCategoryCommand)
    {
        return sender.Send(createCategoryCommand).ToMinimalApiResult();
    }
}
