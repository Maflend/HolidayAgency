using AutoMapper;
using HA.Application.Common.Models.Errors;
using HA.Application.Dependencies.DataAccess.Common.Queries;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Clients;
using HA.ResultDomain;
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
public class GetClientByidQueryHandler(IApplicationDbContext _dbContext, IMapper _mapper) 
    : IRequestHandler<GetClientByIdQuery, Result<GetClientByIdResponse>>
{
    public async Task<Result<GetClientByIdResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var existingClient = await _dbContext.Set<Client>()
            .GetProjectedByIdAsync<Client, GetClientByIdResponse>(request.Id, _mapper, cancellationToken);

        if (existingClient is null)
        {
            return Result<GetClientByIdResponse>.Fail(new NotFoundError("Клиент не существует."));
        }

        return existingClient;
    }
}
