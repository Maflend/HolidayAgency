using HA.Application.UseCases.OrdersModeration.GetOrderById;

namespace HA.Api.Endpoints.OrdersModeration.GetOrderById;

/// <summary>
/// Конечная точка получения заказа по идентификатору.
/// </summary>
public static class GetOrderByIdEndpoint
{
    /// <summary>
    /// Конечная точка получения заказа по идентификатору.
    /// </summary>
    public static void MapGetOrderByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("{id:guid}", GetByIdAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<GetOrderByIdResponse>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .Produces(StatusCodes.Status404NotFound, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить заказ по идентификатору.";
                opts.Description = "Получить по идентификатору.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetByIdAsync(Guid id, ISender sender)
    {
        return sender.Send(new GetOrderByIdQuery(id)).ToMinimalApiAsync();
    }
}
