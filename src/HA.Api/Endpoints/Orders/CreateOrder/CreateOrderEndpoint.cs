using HA.Api.Extensions;
using HA.Application.Common.Results;
using HA.Application.UseCases.Orders.CreateOrder;
using MediatR;

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
            .Produces(200, typeof(Guid))
            .Produces(400, typeof(Result<>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Создание заказа.";
                opts.Description = "Создание необработанного заказа.";

                return opts;
            });
    }

    internal static Task<IResult> CreateAsync(
        ISender sender,
        CreateOrderCommand createOrderCommand)
    {
        return sender.Send(createOrderCommand).ToMinimalApiAsync();
    }
}
