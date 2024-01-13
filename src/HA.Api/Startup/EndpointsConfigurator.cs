using HA.Api.Endpoints.Categories;
using HA.Api.Endpoints.Clients;
using HA.Api.Endpoints.Orders;
using HA.Application.UseCases.Orders.CreateOrder;

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

        app.MapGet("/log", (ILogger<CreateOrderCommandHandler> logger) =>
        {
            logger.LogInformation("My test message: {MSG}", "123123");
            logger.LogInformation($"My test: {0000}");
        });
        return app;
    }
}
