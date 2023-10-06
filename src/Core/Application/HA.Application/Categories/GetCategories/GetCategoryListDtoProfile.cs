using AutoMapper;
using HA.Domain.Categories;

namespace HA.Application.Categories.GetCategories;
public class GetCategoryListDtoProfile : Profile
{
    public GetCategoryListDtoProfile()
    {
        CreateMap<Category, GetCategoryListDto>();
    }
}

