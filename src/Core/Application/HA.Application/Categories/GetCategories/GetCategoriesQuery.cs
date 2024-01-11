using HA.Application.Common.Models.Paging;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.Categories.GetCategories;

/// <summary>
/// Запрос на получение всех категорий.
/// </summary>
public record GetCategoriesQuery : PagingAndSorting, IRequest<Result<List<GetCategoryListDto>>>;