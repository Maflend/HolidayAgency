using HA.Api.Endpoints.OrdersModeration.ConfirmOrder.Requests;
using HA.Application.UseCases.OrdersModeration.ConfirmOrder;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.OrdersModeration.ConfirmOrder;

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
        group.MapPut("{id:guid}/confirm", ConfirmAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<Guid>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .Produces(StatusCodes.Status404NotFound, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Подтверждение заказа.";
                opts.Description = "Подтверждение заказа.";

                return opts;
            });
    }

    internal static Task<HttpIResult> ConfirmAsync(
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
