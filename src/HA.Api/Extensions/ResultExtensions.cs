using HA.Application.Common.Results;
using HttpIResult = Microsoft.AspNetCore.Http.IResult;

namespace HA.Api.Extensions;

public static class ResultExtensions
{
    /// <summary>
    /// Преобразовать <see cref="IResult"/> в <see cref="Microsoft.AspNetCore.Http.IResult"/>.
    /// </summary>
    public static HttpIResult ToMinimalApi<TResult>(this TResult result) where TResult : Application.Common.Results.IResult
    {
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }

    /// <summary>
    /// Преобразовать <see cref="IResult"/> в <see cref="Microsoft.AspNetCore.Http.IResult"/>.
    /// </summary>
    public static async Task<HttpIResult> ToMinimalApiAsync<TResult>(this Task<TResult> resultTask) where TResult : Application.Common.Results.IResult
    {
        var result = await resultTask;
        return result.ToMinimalApi();
    }
}