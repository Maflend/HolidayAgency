using HA.Application.Orders.GetUnprocessedOrders;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using HA.ResultAsp.MinimalApi;
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
            .Produces(200, typeof(List<GetUnprocessedOrderListDto>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанные заказы.";
                opts.Description = "Получить необработанные заказы.";

                return opts;
            });
    }

    internal static Task<IResult> GetUnprocessedOrdersAsync(
        ISender sender)
    {
        return sender.Send(new GetUnprocessedOrdersQuery()).ToMinimalApiResult();
    }
}