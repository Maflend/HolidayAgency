using AutoMapper;
using AutoMapper.QueryableExtensions;
using HA.Application.Common.Models.Errors;
using HA.Application.Dependencies.Persistence;
using HA.ResultDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Clients.GetClientById;

/// <summary>
/// Запрос на получение клиента по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetClientByIdQuery(Guid Id) : IRequest<Result<GetClientByIdResponse>>;

/// <summary>
/// Обработчик запроса на получение клиента по идентификатору.
/// </summary>
public class GetClientByidQueryHandler(IApplicationDbContext dbContext, IMapper mapper) 
    : IRequestHandler<GetClientByIdQuery, Result<GetClientByIdResponse>>
{
    public async Task<Result<GetClientByIdResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var existingClient = await dbContext.Clients
            .ProjectTo<GetClientByIdResponse>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (existingClient is null)
        {
            return Result<GetClientByIdResponse>.Fail(new NotFoundError("Клиент не существует."));
        }

        return existingClient;
    }
}
