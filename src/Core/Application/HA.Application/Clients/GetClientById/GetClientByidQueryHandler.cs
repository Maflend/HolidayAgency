using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using HA.Application.Clients.GetClientById.Responce;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Clients.GetClientById;

/// <summary>
/// Обработчик запроса на получение клиента по идентификатору.
/// </summary>
public class GetClientByidQueryHandler : IRequestHandler<GetClientByIdQuery, Result<GetClientByIdDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <inheritdoc cref="GetClientByidQueryHandler"/>
    public GetClientByidQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<GetClientByIdDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var existingClient = await _dbContext.Clients
            .ProjectTo<GetClientByIdDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(item=>item.Id == request.Id);

        if (existingClient is null)
        {
            return Result.Fail(new NotFoundError("Клиент не существует."));
        }

        return existingClient;
    }
}

