using HA.Api.Extensions;
using HA.Application.Common.Models.Pagination;
using HA.Application.Common.Results;
using HA.Application.UseCases.Orders.GetUnprocessedOrders;

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
            .Produces(StatusCodes.Status200OK, typeof(Result<PaginatedResponse<GetUnprocessedOrdersResponse>>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанные заказы.";
                opts.Description = "Получить необработанные заказы.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetUnprocessedOrdersAsync(ISender sender, [AsParameters] GetUnprocessedOrdersQuery query)
    {
        return sender.Send(query).ToMinimalApiAsync();
    }
}