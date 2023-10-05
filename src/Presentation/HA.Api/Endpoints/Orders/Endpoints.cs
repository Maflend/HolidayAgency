using HA.Api.Endpoints.Orders.ConfirmOrder;
using HA.Api.Endpoints.Orders.CreateOrder;
using HA.Api.Endpoints.Orders.GetUnprocessedByIdOrders;
using HA.Api.Endpoints.Orders.GetUnprocessedOrders;

namespace HA.Api.Endpoints.Orders;

/// <summary>
/// Конечные точки заказов.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Конечные точки заказов.
    /// </summary>
    public static WebApplication MapOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "orders").WithTags("Конечные точки заказов.");

        group.MapGetUnprocessedOrdersEndpoint();
        group.MapCreateOrderEndpoint();
        group.MapConfirmOrderEndpoint();
        group.MapGetUnprocessedOrderByIdEndpoint();

        return app;
    }
}