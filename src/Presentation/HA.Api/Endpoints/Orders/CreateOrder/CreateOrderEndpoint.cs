using FluentResults.Extensions.AspNetCore;
using HA.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace HA.Api.Endpoints.Orders.CreateOrder;

/// <summary>
/// Конечная точка создания заказа.
/// </summary>
public static class CreateOrderEndpoint
{
    /// <summary>
    /// Конечная точка создания заказа.
    /// </summary>
    public static void MapCreateOrderEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("", CreateAsync)
            .Produces(200, typeof(Guid))
            .Produces(400, typeof(ValidationProblemDetails))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Создание заказа.";
                opts.Description = "Создание необработанного заказа.";
                opts.Parameters = new List<OpenApiParameter>()
                {
                    new OpenApiParameter()
                    {
                        Name = "createOrderCommand",
                        Description = "Информация для создания заказа.",
                        
                    }
                };

                return opts;
            });
    }

    internal static Task<ActionResult> CreateAsync(
        ISender sender,
        CreateOrderCommand createOrderCommand)
    {
        return sender.Send(createOrderCommand).ToActionResult();
    }
}
