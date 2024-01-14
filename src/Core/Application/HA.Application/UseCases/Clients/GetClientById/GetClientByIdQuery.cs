using AutoMapper;
using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Clients;
using MediatR;

namespace HA.Application.UseCases.Clients.GetClientById;

/// <summary>
/// Запрос на получение клиента по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetClientByIdQuery(Guid Id) : IRequest<Result<GetClientByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение клиента по идентификатору.
/// </summary>
public class GetClientByidQueryHandler(IDbContext _dbContext, IMapper _mapper)
    : IRequestHandler<GetClientByIdQuery, Result<GetClientByIdResponse>>
{
    public async Task<Result<GetClientByIdResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Client>()
            .GetProjectedByIdAsync<Client, GetClientByIdResponse>(request.Id, _mapper, cancellationToken)
            .ThrowResourceNotFound(typeof(Client), request.Id);
    }
}
