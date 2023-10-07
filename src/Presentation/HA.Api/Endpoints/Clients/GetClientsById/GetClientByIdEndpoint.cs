using FluentResults.Extensions.AspNetCore;
using HA.Application.Clients.GetClientById;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Clients.GetClientsById;

public static class GetClientByIdEndpoint
{
    public static void MapGetClientByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}", GetClientByIdAsync)
            .Produces(200, typeof(GetUnprocessedOrderListDto))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить клиента по идентификатору.";
                opts.Description = "Получить клиента по идентификатору.";

                return opts;
            });
    }

    internal static Task<ActionResult> GetClientByIdAsync(
        [FromRoute] Guid id,
        ISender sender)
    {
        return sender.Send(new GetClientByIdQuery(id)).ToActionResult();
    }
}

