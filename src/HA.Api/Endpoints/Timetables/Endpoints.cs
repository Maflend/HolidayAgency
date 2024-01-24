using HA.Api.Endpoints.Timetables.GetTimetable;

namespace HA.Api.Endpoints.Timetables;

/// <summary>
/// Конечные точки расписания.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Конечные точки расписания.
    /// </summary>
    public static WebApplication MapTimetablesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "timetables").WithTags("Конечные точки расписания.");

        group.MapGetTimetableEndpoint();

        return app;
    }
}