using HA.Api.Endpoints.OrdersModeration.ConfirmOrder;
using HA.Api.Endpoints.OrdersModeration.GetOrderById;
using HA.Api.Endpoints.OrdersModeration.GetOrders;

namespace HA.Api.Endpoints.OrdersModeration;

/// <summary>
/// Конечные точки модерации заказов.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Конечные точки модерации заказов.
    /// </summary>
    public static WebApplication MapOrdersModerationEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "moderation/orders").WithTags("Конечные точки модерации заказов.");

        group.MapGetOrdersEndpoint();
        group.MapConfirmOrderEndpoint();
        group.MapGetOrderByIdEndpoint();

        return app;
    }
}