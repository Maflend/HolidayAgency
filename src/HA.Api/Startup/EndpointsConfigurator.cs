using HA.Api.Endpoints.Categories;
using HA.Api.Endpoints.ClientOrders;
using HA.Api.Endpoints.Clients;
using HA.Api.Endpoints.OrdersModeration;
using HA.Api.Endpoints.Timetables;

namespace HA.Api.Startup;

/// <summary>
/// Конфигуратор endpoints.
/// </summary>
public static class EndpointsConfigurator
{
    /// <summary>
    /// Использовать конечные точки.
    /// </summary>
    public static WebApplication UseEndpoints(this WebApplication app)
    {
        app.MapCategoryEndpoints();
        app.MapClientOrdersEndpoints();
        app.MapСlientsEndpoints();
        app.MapOrdersModerationEndpoints();
        app.MapTimetablesEndpoints();

        return app;
    }
}
