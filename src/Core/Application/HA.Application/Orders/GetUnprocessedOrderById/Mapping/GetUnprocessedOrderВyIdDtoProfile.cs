using AutoMapper;
using HA.Application.Orders.GetUnprocessedOrderById.Responce;
using HA.Domain.Clients;
using HA.Domain.Orders;

namespace HA.Application.Orders.GetUnprocessedOrderById.Mapping;

/// <summary>
/// Профиль для мапинга Неотсортированных заказов по идентификатору.
/// </summary>
public class GetUnprocessedOrderВyIdDtoProfile : Profile
{
    /// <inheritdoc cref="GetUnprocessedOrderВyIdDtoProfile"/>
    public GetUnprocessedOrderВyIdDtoProfile()
    {
        CreateMap<Client, ClientInfoDto>();

        CreateMap<UnprocessedOrder, GetUnprocessedOrderByIdDto>()
            .ForMember(item => item.CategoryName,
            opt =>
            opt.MapFrom(item => item.Category.Name));
    }
}

