using HA.Api.Dtos;
using HA.Domain.Entities;
using HA.Domain.Entities.Orders;
using HA.Domain.ValueObjects;

namespace HA.Api.Endpoints;

public static class OrderEndpoints
{
    public static WebApplication MapOrderEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/orders");

        group.MapPost("", CreateOrderAsync);

        return app;
    }

    public static IResult CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var category = DataStorage.Categories.FirstOrDefault(c => c.Id == createOrderDto.CategoryId);

        if (category is null)
        {
            return Results.NotFound("Категория не найдена");
        }

        var client = DataStorage.Clients.FirstOrDefault(c => c.Phone == createOrderDto.Phone);

        client ??= new Client(new FullName(createOrderDto.FirstName, createOrderDto.LastName, createOrderDto.Patronymic), createOrderDto.Phone);

        var priceList = new PriceList();

        var order = new NewOrder(
            category,
            priceList,
            client,
            createOrderDto.EventDate,
            createOrderDto.Address,
            createOrderDto.CountHourse,
            createOrderDto.CountPeople);

        DataStorage.NewOrders.Add(order);

        return Results.Ok();
    }
}
