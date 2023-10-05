using FluentResults;
using MediatR;

namespace HA.Application.Categories.GetCategoryById;

/// <summary>
/// Запрос на получение категории по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetCategoryByIdQuery(Guid Id) : IRequest<Result<GetCategoryDto>>;

