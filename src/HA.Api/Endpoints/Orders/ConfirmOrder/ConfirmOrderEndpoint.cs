using HA.Api.Endpoints.Orders.ConfirmOrder.Requests;
using HA.Api.Extensions;
using HA.Application.UseCases.Orders.ConfirmOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        group.MapPost("{id:guid}/confirm", ConfirmAsync)
            .Produces(200, typeof(Guid))
            .Produces(400, typeof(Application.Common.Results.Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Подтверждение заказа.";
                opts.Description = "Подтверждение необработанного заказа.";

                return opts;
            });
    }

    internal static Task<IResult> ConfirmAsync(
        ISender sender,
        [FromRoute] Guid id,
        [FromBody] ConfirmOrderRequest confirmOrderRequest)
    {
        return sender.Send(new ConfirmOrderCommand(
           id,
           confirmOrderRequest.EventPlan,
           confirmOrderRequest.Peoples,
           confirmOrderRequest.DiscountPerHour)).ToMinimalApiAsync();
    }
}
