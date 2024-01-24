using AutoMapper;
using HA.Application.Common.Mappings;
using HA.Application.UseCases.OrdersModeration.GetOrders.Responses;
using HA.Domain.Orders;

namespace HA.Application.UseCases.OrdersModeration.GetOrders;

/// <summary>
/// Информация о необработанном заказе.
/// </summary>
public class GetOrdersResponse : IMapFrom<Order>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime EventDate { get; set; }

    /// <summary>
    /// Адрес проведения.
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Количество часов.
    /// </summary>
    public double NumberOfHours { get; set; }

    /// <summary>
    /// Количество людей.
    /// </summary>
    public int NumberOfPeople { get; set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public GetOrdersClientInfoDto Client { get; set; } = null!;

    /// <summary>
    /// Категория.
    /// </summary>
    public string CategoryName { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, GetOrdersResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}
