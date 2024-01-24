using HA.Application.Common.Results;
using MediatR;

namespace HA.Application.UseCases.ClientOrders.CreateOrder;

public record CreateOrderCommand(
    string FirstName,
    string LastName,
    string? Patronymic,
    string Phone,
    DateTime StartDate,
    DateTime EndDate,
    string? Address,
    Guid CategoryId) : IRequest<Result<Guid>>;
