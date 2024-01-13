using HA.Api.Endpoints.Categories;
using HA.Api.Endpoints.Clients;
using HA.Api.Endpoints.Orders;

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
        app.MapOrdersEndpoints();
        app.MapСlientsEndpoints();

        return app;
    }
}
