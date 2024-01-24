using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Clients.Queries;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Orders;
using MediatR;

namespace HA.Application.UseCases.ClientOrders.CreateOrder;

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

        var order = new Order(
            category,
            client,
            request.StartDate,
            request.EndDate,
            request.Address);

        await dbContext.Set<Order>().AddAsync(order, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
