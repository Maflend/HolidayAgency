using HA.Application.UseCases.Clients.GetClientById;
using HA.ResultAsp.MinimalApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    internal static Task<IResult> GetClientByIdAsync(
        [FromRoute] Guid id,
        ISender sender)
    {
        return sender.Send(new GetClientByIdQuery(id)).ToMinimalApiResult();
    }
}

