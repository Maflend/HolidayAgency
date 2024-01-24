using AutoMapper;
using HA.Application.Common.Mappings;
using HA.Application.UseCases.OrdersModeration.GetOrderById.Responces;
using HA.Domain.Common;
using HA.Domain.Orders;

namespace HA.Application.UseCases.OrdersModeration.GetOrderById;

/// <summary>
/// Информация о необработанном заказе.
/// </summary>
public class GetOrderByIdResponse : IHasId, IMapFrom<Order>
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
    /// Категория.
    /// </summary>
    public string CategoryName { get; set; } = null!;

    /// <summary>
    /// Клиент.
    /// </summary>
    public GetUnprocessedOrderByIdClientInfoDto Client { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, GetOrderByIdResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}

