using AutoMapper;
using FluentResults;
using HA.Application.Common.Models.Errors;
using HA.Application.Common.Persistence;
using HA.Domain.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Categories.GetCategoryById;

/// <summary>
/// Обработчик запроса на получение категории по идентификатору.
/// </summary>
public class GetCategoryByIdQyeryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryDto>>
{
    private IApplicationDbContext _dbcontext;
    private IMapper _mapper;

    /// <inheritdoc cref="GetCategoryByIdQyeryHandler"/>
    public GetCategoryByIdQyeryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbcontext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<GetCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var existingUnprocessedOrder =
            await _dbcontext.Categories
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (existingUnprocessedOrder is null)
        {
            return Result.Fail(new NotFoundError("Категория с данным идентификатором не существует."));
        }

        return _mapper.Map<Category, GetCategoryDto>(existingUnprocessedOrder);
    }

}

