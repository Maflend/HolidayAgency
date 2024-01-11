using AutoMapper;
using HA.Application.UseCases.Orders.GetUnprocessedOrderById.Responces;
using HA.Domain.Clients;
using HA.Domain.Orders;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrderById.Mapping;

/// <summary>
/// Профиль для мапинга Неотсортированных заказов по идентификатору.
/// </summary>
public class GetUnprocessedOrderВyIdDtoProfile : Profile
{
    /// <inheritdoc cref="GetUnprocessedOrderВyIdDtoProfile"/>
    public GetUnprocessedOrderВyIdDtoProfile()
    {
        CreateProjection<Client, GetUnprocessedOrderByIdClientInfoDto>();

        CreateProjection<UnprocessedOrder, GetUnprocessedOrderByIdResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}

