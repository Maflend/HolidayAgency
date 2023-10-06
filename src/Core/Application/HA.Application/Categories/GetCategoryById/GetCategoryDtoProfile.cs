using AutoMapper;
using HA.Domain.Categories;

namespace HA.Application.Categories.GetCategoryById;

/// <summary>
/// Профиль для мапинга полученных категорий по идентификатору.
/// </summary>
public class GetCategoryDtoProfile : Profile
{
    /// <inheritdoc cref="GetCategoryDtoProfile"/>
    public GetCategoryDtoProfile()
    {
        CreateMap<Category, GetCategoryDto>();
    }
}

