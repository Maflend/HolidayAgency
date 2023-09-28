using HA.Domain.ValueObjects;
using MediatR;

namespace HA.Application.Orders.GetNewOrder;

public record GetNewOrderQuery(
    Guid Id,
    DateTime EventDate,
    double CountHourse,
    string Address,
    Category Category,
    Client Client
) : IRequest;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class Client
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
}

public class GetNewOrderQueryHandler : IRequestHandler<GetNewOrderQuery>
{
    public GetNewOrderQueryHandler()
    {

    }

    public async Task Handle(GetNewOrderQuery request, CancellationToken cancellationToken)
    {
        //var category = DataStorage.Categories.FirstOrDefault(c => c.Id == createOrderDto.CategoryId);

        //if (category is null)
        //{
        //    return Results.NotFound("Категория не найдена");
        //}

        //var client = DataStorage.Clients.FirstOrDefault(c => c.Phone == createOrderDto.Phone);

        //client ??= new Client(new FullName(createOrderDto.FirstName, createOrderDto.LastName, createOrderDto.Patronymic), createOrderDto.Phone);

        //var priceList = new PriceList();

        //var order = new NewOrder(
        //    category,
        //    priceList,
        //    client,
        //    createOrderDto.EventDate,
        //    createOrderDto.Address,
        //    createOrderDto.CountHourse,
        //    createOrderDto.CountPeople);

        //DataStorage.NewOrders.Add(order);

        //return Results.Ok();
    }
}