using HA.Api.Endpoints.ClientOrders.CreateOrder;

namespace HA.Api.Endpoints.ClientOrders;

/// <summary>
/// Конечные точки заказов клиента.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Конечные точки заказов клиента.
    /// </summary>
    public static WebApplication MapClientOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "client-orders").WithTags("Конечные точки заказов клиента.");

        group.MapCreateOrderEndpoint();

        return app;
    }
}