using HA.Application.Common.Results;
using HA.Application.UseCases.Clients.GetClientById;
using MediatR;

namespace HA.Api.Endpoints.Clients.GetClientById;

public static class GetClientByIdEndpoint
{
    public static void MapGetClientByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id}", GetClientByIdAsync)
            .Produces(200, typeof(GetClientByIdResponse))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить клиента по идентификатору.";
                opts.Description = "Получить клиента по идентификатору.";

                return opts;
            });
    }

    internal static Task<Result<GetClientByIdResponse>> GetClientByIdAsync(
        Guid id,
        ISender sender)
    {
        return sender.Send(new GetClientByIdQuery(id));
    }
}

