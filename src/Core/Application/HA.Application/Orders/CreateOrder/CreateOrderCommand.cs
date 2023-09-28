using MediatR;

namespace HA.Application.Orders.CreateOrder;
public record CreateOrderCommand(
    string FirstName,
    string LastName,
    string Patronymic,
    string Phone,
    DateTime EventDate,
    double CountHourse,
    string Address,
    int CountPeople,
    Guid CategoryId) : IRequest;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
{
    public CreateOrderHandler()
    {
        
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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
