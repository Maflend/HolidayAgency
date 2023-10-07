

using HA.Api.Endpoints.Clients.GetClientsById;

namespace HA.Api.Endpoints.Clients;


/// <summary>
/// Конечные точки клиентов.
/// </summary>
public static class Endpoint
{
    /// <summary>
    /// Конечные точки клиентов.
    /// </summary>
    public static WebApplication MapСlientsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "clients").WithTags("Конечные точки клиентов.");

        group.MapGetClientByIdEndpoint();

        return app;
    }
}

