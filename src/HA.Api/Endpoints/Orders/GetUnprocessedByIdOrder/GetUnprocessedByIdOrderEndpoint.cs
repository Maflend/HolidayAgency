using HA.Api.Extensions;
using HA.Application.UseCases.Orders.GetUnprocessedOrderById;
using MediatR;

namespace HA.Api.Endpoints.Orders.GetUnprocessedByIdOrder;

public static class GetUnprocessedByIdOrderEndpoint
{
    public static void MapGetUnprocessedOrderByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id:guid}/unprocessed", GetUnprocessedOrderByIdAsync)
            .Produces(200, typeof(GetUnprocessedOrderByIdResponse))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанный заказ по идентификатору.";
                opts.Description = "Получить необработанный по идентификатору.";

                return opts;
            });
    }

    internal static Task<IResult> GetUnprocessedOrderByIdAsync(
        Guid id,
        ISender sender)
    {
        return sender.Send(new GetUnprocessedOrderByIdQuery(id)).ToMinimalApiAsync();
    }
}
