using FluentResults.Extensions.AspNetCore;
using HA.Application.Orders.GetUnprocessedOrderById;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Orders.GetUnprocessedByIdOrders;
public static class GetUnprocessedByIdOrderEndpoint
{
    public static void MapGetUnprocessedOrdersByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}", GetUnprocessedOrdersAsync)
            .Produces(200, typeof(List<GetUnprocessedOrderListDto>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанные заказы по идентификатору.";
                opts.Description = "Получить необработанные по идентификатору.";

                return opts;
            });
    }

    internal static Task<ActionResult> GetUnprocessedOrdersAsync([FromRoute] Guid id,
        ISender sender)
    {
        return sender.Send(new GetUnprocessedOrderByIdQuery(id)).ToActionResult();
    }
}

