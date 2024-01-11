using HA.Application.UseCases.Orders.GetUnprocessedOrderById;
using HA.ResultAsp.MinimalApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Orders.GetUnprocessedByIdOrder;

public static class GetUnprocessedByIdOrderEndpoint
{
    public static void MapGetUnprocessedOrderByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}/unprocessed", GetUnprocessedOrderByIdAsync)
            .Produces(200, typeof(GetUnprocessedOrderByIdResponse))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанный заказ по идентификатору.";
                opts.Description = "Получить необработанный по идентификатору.";

                return opts;
            });
    }

    internal static Task<IResult> GetUnprocessedOrderByIdAsync(
        [FromRoute] Guid id,
        ISender sender)
    {
        return sender.Send(new GetUnprocessedOrderByIdQuery(id)).ToMinimalApiResult();
    }
}

