using FluentResults;
using MediatR;

namespace HA.Application.Categories.GetCategories;

/// <summary>
/// Запрос на получение всех категорий.
/// </summary>
public record GetCategoriesQuery : IRequest<Result<List<GetCategoryListDto>>>;
