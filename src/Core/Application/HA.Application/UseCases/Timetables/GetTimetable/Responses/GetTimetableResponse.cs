using AutoMapper;
using HA.Application.Common.Mappings;
using HA.Domain.Orders;

namespace HA.Application.UseCases.Timetables.GetTimetable.Responses;

public class GetTimetableResponse() : IMapFrom<Order>
{
    public TimetableOrderStatus Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, GetTimetableResponse>()
            .ForMember(dest => dest.Status, opt => opt.ConvertUsing(new OrderStatusValueConverter()));
    }
}

public class OrderStatusValueConverter : IValueConverter<OrderStatus, TimetableOrderStatus>
{
    public TimetableOrderStatus Convert(OrderStatus sourceMember, ResolutionContext context)
    {
        return sourceMember switch
        {
            OrderStatus.Unprocessed => TimetableOrderStatus.OnConfirmation,
            OrderStatus.Confirmed => TimetableOrderStatus.Busy,
            _ => TimetableOrderStatus.Free
        };
    }
}
