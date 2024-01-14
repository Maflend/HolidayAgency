using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Clients.Queries;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.Orders.CreateOrder;

public class CreateOrderCommandHandler(IDbContext dbContext) 
    : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var client = await dbContext.Set<Client>().GetByPhoneAsync(request.Phone, cancellationToken);

        client ??= new Client(request.FirstName, request.LastName, request.Phone, request.Patronymic);

        var category = await dbContext.Set<Category>().GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
            return Result<Guid>.Fail(new Error("CreateOrder.CategoryNotFound"));

        var unprocessedOrder = new UnprocessedOrder(
            category!,
            client,
            request.EventDate,
            request.Address,
            request.CountHourse,
            request.CountPeople);

        await dbContext.Set<UnprocessedOrder>().AddAsync(unprocessedOrder, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        // TODO: После создания заказа можно с помощью шины событий кидать событие создание заказа.
        // Это событие будет обрабатывать сервис интеграции с ТГ который отправит уведомление сотруднику.

        return unprocessedOrder.Id;
    }
}
