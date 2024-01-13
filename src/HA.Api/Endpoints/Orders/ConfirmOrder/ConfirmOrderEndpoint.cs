using HA.Api.Endpoints.Orders.ConfirmOrder.Requests;
using HA.Api.Extensions;
using HA.Application.Common.Results;
using HA.Application.UseCases.Orders.ConfirmOrder;
using MediatR;
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
            .Produces(400, typeof(Result<>))
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
                    }
                };

                return opts;
            });
    }

    internal static Task<IResult> ConfirmAsync(
     ISender sender,
     Guid id,
     ConfirmOrderRequest confirmOrderRequest)
    {
        return sender.Send(new ConfirmOrderCommand(
           id,
           confirmOrderRequest.EventPlan,
           confirmOrderRequest.Peoples,
           confirmOrderRequest.DiscountPerHour)).ToMinimalApiAsync();
    }
}
