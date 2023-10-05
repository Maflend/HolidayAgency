using FluentResults.Extensions.AspNetCore;
using HA.Application.Orders.GetUnprocessedOrderById;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Orders.GetUnprocessedByIdOrders;

public static class GetUnprocessedByIdOrderEndpoint
{
    public static void MapGetUnprocessedOrderByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}/unprocessed", GetUnprocessedOrderByIdAsync)
            .Produces(200, typeof(GetUnprocessedOrderListDto))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанный заказ по идентификатору.";
                opts.Description = "Получить необработанный по идентификатору.";

                return opts;
            });
    }

    internal static Task<ActionResult> GetUnprocessedOrderByIdAsync(
        [FromRoute] Guid id,
        ISender sender)
    {
        return sender.Send(new GetUnprocessedOrderByIdQuery(id)).ToActionResult();
    }
}

