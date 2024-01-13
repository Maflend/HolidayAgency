using HA.Application.Common.Results;

namespace HA.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToMinimalApi<TResult>(this TResult result) where TResult : ResultBase
    {
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }

    public static async Task<IResult> ToMinimalApiAsync<TResult>(this Task<TResult> resultTask) where TResult : ResultBase
    {
        var result = await resultTask;
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}