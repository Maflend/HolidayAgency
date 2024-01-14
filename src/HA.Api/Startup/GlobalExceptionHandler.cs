using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using Microsoft.AspNetCore.Diagnostics;

namespace HA.Api.Startup;

/// <summary>
/// Глобальный обработчик исключений.
/// </summary>
internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        if (exception is ResourceNotFoundException resourceNotFoundException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            var result = Result<ResultDataEmpty>.Fail(new Error("ResourceNotFound", resourceNotFoundException.Message));
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        }

        if (exception is InvalidPaginationException invalidPaginationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            var result = Result<ResultDataEmpty>.Fail(new Error("Pagination", invalidPaginationException.Message));
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        }

        return true;
    }
}
