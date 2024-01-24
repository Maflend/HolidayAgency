using HA.Application.UseCases.OrdersModeration.GetOrderById;
using HA.Application.UseCases.Timetables.GetTimetable;

namespace HA.Api.Endpoints.Timetables.GetTimetable;

/// <summary>
/// Конечная точка получения расписания
/// </summary>
public static class GetTimetableEndpoint
{
    /// <summary>
    /// Конечная точка получения расписания.
    /// </summary>
    public static void MapGetTimetableEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("", GetAsync)
            .Produces(StatusCodes.Status200OK, typeof(Result<GetOrderByIdResponse>))
            .WithOpenApi(opts =>
            {
                opts.Summary = "Получить расписание.";
                opts.Description = "Получить расписание.";

                return opts;
            });
    }

    internal static Task<HttpIResult> GetAsync(ISender sender)
    {
        return sender.Send(new GetTimetableQuery()).ToMinimalApiAsync();
    }
}
