using FluentResults;
using HA.Application.Clients.GetClientById.Responce;
using MediatR;

namespace HA.Application.Clients.GetClientById;

/// <summary>
/// Запрос на получение клиента по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetClientByIdQuery(Guid Id) : IRequest<Result<GetClientByIdDto>>;
