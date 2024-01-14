using HA.Application.UseCases.Orders.GetUnprocessedOrderById;

namespace HA.Api.Endpoints.Orders.GetUnprocessedByIdOrder;

/// <summary>
/// Конечная точка получения необработанного заказа по идентификатору.
/// </summary>
public static class GetUnprocessedByIdOrderEndpoint
{
    /// <summary>
    /// Конечная точка получения необработанного заказа по идентификатору.
    /// </summary>
    public static void MapGetUnprocessedOrderByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id:guid}/unprocessed", GetUnprocessedOrderByIdAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<GetUnprocessedOrderByIdResponse>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .Produces(StatusCodes.Status404NotFound, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить необработанный заказ по идентификатору.";
                opts.Description = "Получить необработанный по идентификатору.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetUnprocessedOrderByIdAsync(Guid id, ISender sender)
    {
        return sender.Send(new GetUnprocessedOrderByIdQuery(id)).ToMinimalApiAsync();
    }
}
