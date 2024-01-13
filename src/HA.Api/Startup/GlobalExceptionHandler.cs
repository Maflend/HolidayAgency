using HA.Application.Common.Exceptions;
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

        return true;
    }
}
