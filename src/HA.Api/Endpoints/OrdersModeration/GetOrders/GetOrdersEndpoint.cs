using HA.Application.Common.Models.Pagination;
using HA.Application.UseCases.OrdersModeration.GetOrders;

namespace HA.Api.Endpoints.OrdersModeration.GetOrders;

/// <summary>
/// Конечная точка получения заказов.
/// </summary>
public static class GetOrdersEndpoint
{
    /// <summary>
    /// Конечная точка получения заказов.
    /// </summary>
    public static void MapGetOrdersEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("unprocessed", GetOrdersAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<PaginatedResponse<GetOrdersResponse>>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить заказы.";
                opts.Description = "Получить заказы.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetOrdersAsync(ISender sender, [AsParameters] GetOrdersQuery query)
    {
        return sender.Send(query).ToMinimalApiAsync();
    }
}