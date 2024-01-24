using AutoMapper;
using HA.Application.Common.Results;
using HA.Application.Dependencies.Persistence;
using HA.Application.UseCases.Timetables.GetTimetable.Responses;
using HA.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.UseCases.Timetables.GetTimetable;
public record GetTimetableQuery : IRequest<Result<List<GetTimetableResponse>>>;

public class GetTimetableQueryHandler(IDbContext _dbContext, IMapper _mapper, TimeProvider _timeProvider)
    : IRequestHandler<GetTimetableQuery, Result<List<GetTimetableResponse>>>
{
    public async Task<Result<List<GetTimetableResponse>>> Handle(GetTimetableQuery request, CancellationToken cancellationToken)
    {
        var currentDate = _timeProvider.GetUtcNow();

        var orders = await _dbContext.Set<Order>()
            .Where(order => order.Status == OrderStatus.Confirmed || order.Status == OrderStatus.Unprocessed)
            .Where(order => order.StartDate >= currentDate)
            .ToListAsync(cancellationToken);

        var timetable = _mapper.Map<List<GetTimetableResponse>>(orders);

        return timetable;
    }
}
