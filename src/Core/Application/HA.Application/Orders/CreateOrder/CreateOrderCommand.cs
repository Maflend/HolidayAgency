using FluentResults;
using MediatR;

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
    Guid CategoryId) : IRequest<Result<Guid>>;
