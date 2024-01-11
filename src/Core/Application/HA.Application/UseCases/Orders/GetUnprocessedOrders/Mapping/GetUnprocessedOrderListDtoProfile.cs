using AutoMapper;
using HA.Application.UseCases.Orders.GetUnprocessedOrders.Responses;
using HA.Domain.Clients;
using HA.Domain.Orders;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrders.Mapping;

/// <summary>
/// Профиль для мапинга Неотсортированных заказов.
/// </summary>
public class GetUnprocessedOrderListDtoProfile : Profile
{
    /// <inheritdoc cref="GetUnprocessedOrderListDtoProfile"/>
    public GetUnprocessedOrderListDtoProfile()
    {
        CreateProjection<Client, GetUnprocessedOrdersClientInfoDto>();

        CreateProjection<UnprocessedOrder, GetUnprocessedOrdersResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}

