using AutoMapper;
using HA.Application.Common.Mapping;
using HA.Application.UseCases.Orders.GetUnprocessedOrderById.Responces;
using HA.Domain.Orders;

namespace HA.Application.UseCases.Orders.GetUnprocessedOrderById;

/// <summary>
/// Информация о необработанном заказе.
/// </summary>
public class GetUnprocessedOrderByIdResponse : IMapFrom<UnprocessedOrder>
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
    public double CountHours { get; set; }

    /// <summary>
    /// Количество людей.
    /// </summary>
    public int CountPeople { get; set; }

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
        profile.CreateMap<UnprocessedOrder, GetUnprocessedOrderByIdResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}

