using HA.Application.Common.Exceptions;
using HA.Application.Common.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Startup;

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

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = resourceNotFoundException.Message,
                Type = "Resource not found"
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        if (exception is InvalidPaginationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            var result = Result<ResultEmpty>.Fail(new Error("Pagination", "Неверные параметры для постраничного получения"));
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        }

        return true;
    }
}
