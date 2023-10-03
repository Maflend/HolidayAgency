using FluentResults.Extensions.AspNetCore;
using HA.Api.Endpoints.Orders.ConfirmOrder.Requests;
using HA.Application.Orders.ConfirmOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace HA.Api.Endpoints.Orders.ConfirmOrder;

/// <summary>
/// Конечная точка подтверждения заказа.
/// </summary>
public static class ConfirmOrderEndpoint
{
    /// <summary>
    /// Конечная точка подтверждения заказа.
    /// </summary>
    public static void MapConfirmOrderEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("{id}/confirm", ConfirmAsync)
            .Produces(200, typeof(Guid))
            .Produces(400, typeof(ValidationProblemDetails))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Подтверждение заказа.";
                opts.Description = "Подтверждение необработанного заказа.";
                opts.Parameters = new List<OpenApiParameter>()
                {
                    new OpenApiParameter()
                    {
                        Name = "id",
                        In = ParameterLocation.Query,
                        Description = "Идентификатор необработанного заказа.",
                        Required = true
                    },
                    new OpenApiParameter()
                    {
                        Name = "confirmOrderRequest",
                        Description = "Информация для подтверждения заказа.",
                        Required = true
                    }
                };

                return opts;
            });
    }

    internal static Task<ActionResult> ConfirmAsync(
     ISender sender,
     [FromRoute] Guid id,
     [FromBody] ConfirmOrderRequest confirmOrderRequest)
    {
        return sender.Send(new ConfirmOrderCommand(
           id,
           confirmOrderRequest.EventPlan,
           confirmOrderRequest.Peoples,
           confirmOrderRequest.DiscountPerHour)).ToActionResult();
    }
}
