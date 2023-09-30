using FluentResults;
using HA.Application.Common.Persistence;
using HA.Domain.Entities;
using HA.Domain.Entities.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateOrderCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients
            .FirstOrDefaultAsync(c => c.Phone == request.Phone, cancellationToken);

        client ??= new Client(request.FirstName, request.LastName, request.Phone, request.Patronymic);

        var category = await _dbContext.Categories.SingleAsync(c => c.Id == request.CategoryId, cancellationToken);

        var unprocessedOrder = new UnprocessedOrder(
            category!,
            client,
            request.EventDate,
            request.Address,
            request.CountHourse,
            request.CountPeople);

        await _dbContext.UnprocessedOrders.AddAsync(unprocessedOrder, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        //TODO: После создания заказа можно с помощью шины событий кидать событие создание заказа.
        // Это событие будет обрабатывать сервис интеграции с ТГ который отправит уведомление сотруднику.

        return unprocessedOrder.Id;
    }
}
