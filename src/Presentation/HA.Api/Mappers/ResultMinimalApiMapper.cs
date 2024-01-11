using HA.Application.Common.Models.Errors;
using HA.ResultAsp.MinimalApi.Mappers;
using HA.ResultDomain;
using System.Net;

namespace HA.Api.Mappers;

public class ResultsMinimalApiMapper : IResultMapper
{
    public IResult MapFail<T>(Result<T> result)
    {
        return result.Error switch
        {
            ValidationError => Results.BadRequest(result),
            NotFoundError => Results.NotFound(result),
            _ => Results.StatusCode((int)HttpStatusCode.InternalServerError)
        };
    }

    public IResult MapSuccess<T>(Result<T> result)
    {
        return result.Value is null ? Results.NoContent() : Results.Ok(result);
    }
}
