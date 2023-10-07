using AutoMapper;
using HA.Domain.Categories;

namespace HA.Application.Categories.GetCategories;

/// <summary>
/// Профиль для мапинга полученных категорий.
/// </summary>
public class GetCategoryListDtoProfile : Profile
{
    /// <inheritdoc cref="GetCategoryListDtoProfile"/>
    public GetCategoryListDtoProfile()
    {
        CreateProjection<Category, GetCategoryListDto>();
    }
}

