using HA.Application.UseCases.Orders.CreateOrder;

namespace HA.Api.Endpoints.Orders.CreateOrder;

/// <summary>
/// Конечная точка создания заказа.
/// </summary>
public static class CreateOrderEndpoint
{
    /// <summary>
    /// Конечная точка создания заказа.
    /// </summary>
    public static void MapCreateOrderEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("", CreateAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<Guid>))
            .Produces(StatusCodes.Status400BadRequest, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Создание заказа.";
                opts.Description = "Создание необработанного заказа.";

                return opts;
            });
    }

    internal static Task<HttpIResult> CreateAsync(
        ISender sender,
        CreateOrderCommand createOrderCommand)
    {
        return sender.Send(createOrderCommand).ToMinimalApiAsync();
    }
}
