using HA.Application.Common.Persistence;
using HA.Domain.Entities;
using HA.Domain.Entities.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.CreateOrder;
public record CreateOrderCommand(
    string FirstName,
    string LastName,
    string? Patronymic,
    string Phone,
    DateTime EventDate,
    double CountHourse,
    string Address,
    int CountPeople,
    Guid CategoryId) : IRequest;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateOrderHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);

        if (category is null)
        {
            //return Results.NotFound("Категория не найдена");
        }

        var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Phone == request.Phone, cancellationToken);
        client ??= new Client(request.FirstName, request.LastName, request.Phone, request.Patronymic);


        var unprocessedOrder = new UnprocessedOrder(
            category!,
            client,
            request.EventDate,
            request.Address,
            request.CountHourse,
            request.CountPeople);

        await _dbContext.UnprocessedOrders.AddAsync(unprocessedOrder, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
