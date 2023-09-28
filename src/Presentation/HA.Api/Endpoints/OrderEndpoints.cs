using HA.Application.Orders.CreateOrder;
using MediatR;

namespace HA.Api.Endpoints;

public static class OrderEndpoints
{
    public static WebApplication MapOrderEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/orders");

        group.MapPost("", CreateOrderAsync);

        return app;
    }

    public static Task CreateOrderAsync(
        ISender sender,
        CreateOrderCommand createOrderCommand)
    {
        return sender.Send(createOrderCommand);
    }
}
