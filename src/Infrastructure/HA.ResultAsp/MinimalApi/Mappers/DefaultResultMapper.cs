using HA.ResultDomain;
using Microsoft.AspNetCore.Http;

namespace HA.ResultAsp.MinimalApi.Mappers;

public class DefaultResultMapper : IResultMapper
{
    public IResult MapFail<T>(Result<T> result)
    {
        return Results.Ok(result);
    }

    public IResult MapSuccess<T>(Result<T> result)
    {
        return Results.BadRequest(result);
    }
}
