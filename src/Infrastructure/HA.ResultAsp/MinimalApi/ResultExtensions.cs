using HA.ResultDomain;
using Microsoft.AspNetCore.Http;

namespace HA.ResultAsp.MinimalApi;

public static partial class ResultExtensions
{
    public static IResult ToMinimalApiResult<T>(this Result<T> result)
    {
        return result.IsSuccess ?
            MapperProvider.Mapper.MapSuccess(result) :
            MapperProvider.Mapper.MapFail(result);
    }

    public static async Task<IResult> ToMinimalApiResult<T>(this Task<Result<T>> task)
    {
        var result = await task;
        return result.IsSuccess ?
            MapperProvider.Mapper.MapSuccess(result) :
            MapperProvider.Mapper.MapFail(result);
    }
}
