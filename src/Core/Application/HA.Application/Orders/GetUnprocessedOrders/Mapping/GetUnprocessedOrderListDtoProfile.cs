using AutoMapper;
using HA.Application.Orders.GetUnprocessedOrders.Response;
using HA.Domain.Clients;
using HA.Domain.Orders;

namespace HA.Application.Orders.GetUnprocessedOrders.Mapping;

/// <summary>
/// Профиль для мапинга Неотсортированных заказов.
/// </summary>
public class GetUnprocessedOrderListDtoProfile : Profile
{
    /// <inheritdoc cref="GetUnprocessedOrderListDtoProfile"/>
    public GetUnprocessedOrderListDtoProfile()
    {
        CreateProjection<Client, ClientInfoDto>();

        CreateProjection<UnprocessedOrder, GetUnprocessedOrderListDto>()
            .ForMember(item => item.CategoryName,
            opt => opt.MapFrom(item => item.Category.Name));

    }
}

