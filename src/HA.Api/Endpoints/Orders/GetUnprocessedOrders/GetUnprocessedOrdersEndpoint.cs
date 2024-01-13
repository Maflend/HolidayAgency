using HA.Api.Extensions;
using HA.Application.UseCases.Orders.GetUnprocessedOrders;
using MediatR;

namespace HA.Api.Endpoints.Orders.GetUnprocessedOrders;

/// <summary>
/// Конечная точка получения необработанных заказов.
/// </summary>
public static class GetUnprocessedOrdersEndpoint
{
    /// <summary>
    /// Конечная точка получения необработанных заказов.
    /// </summary>
    public static void MapGetUnprocessedOrdersEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("unprocessed", GetUnprocessedOrdersAsync)
            .Produces(200, typeof(List<GetUnprocessedOrdersResponse>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанные заказы.";
                opts.Description = "Получить необработанные заказы.";

                return opts;
            });
    }

    internal static Task<IResult> GetUnprocessedOrdersAsync(ISender sender, [AsParameters] GetUnprocessedOrdersQuery query)
    {
        return sender.Send(query).ToMinimalApiAsync();
    }
}