using HA.Api.Endpoints.Orders.ConfirmOrder;
using HA.Api.Endpoints.Orders.CreateOrder;

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

        group.MapCreateOrderEndpoint();
        group.MapConfirmOrderEndpoint();

        return app;
    }
}