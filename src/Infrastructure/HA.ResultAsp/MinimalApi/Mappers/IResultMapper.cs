using HA.ResultDomain;
using Microsoft.AspNetCore.Http;

namespace HA.ResultAsp.MinimalApi.Mappers;

public interface IResultMapper
{
    IResult MapSuccess<T>(Result<T> result);
    IResult MapFail<T>(Result<T> result);
}
