using HA.Application.UseCases.Clients.GetClientById;

namespace HA.Api.Endpoints.Clients.GetClientById;

/// <summary>
/// Конечная точка получения клиента по идентификатору.
/// </summary>
public static class GetClientByIdEndpoint
{
    /// <summary>
    /// Конечная точка получения клиента по идентификатору.
    /// </summary>
    public static void MapGetClientByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id:guid}", GetClientByIdAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<GetClientByIdResponse>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .Produces(StatusCodes.Status404NotFound, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить клиента по идентификатору.";
                opts.Description = "Получить клиента по идентификатору.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetClientByIdAsync(Guid id, ISender sender)
    {
        return sender.Send(new GetClientByIdQuery(id)).ToMinimalApiAsync();
    }
}

