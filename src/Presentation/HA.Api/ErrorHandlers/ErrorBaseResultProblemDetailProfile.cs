using FluentResults.Extensions.AspNetCore;
using HA.Application.Common.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.ErrorHandlers;

public class ErrorBaseResultProblemDetailProfile : DefaultAspNetCoreResultEndpointProfile
{
    public override ActionResult TransformFailedResultToActionResult(FailedResultToActionResultTransformationContext context)
    {
        var result = context.Result;

        if (result.HasError<ErrorBase>(out var errors))
        {
            var error = errors.First();

            return error switch
            {
                NotFoundError => new NotFoundObjectResult(BuildProblemDetails(error)),
                ValidationError validationError => new BadRequestObjectResult(BuildValidationProblemDetails(validationError)),
                _ => new StatusCodeResult(500)
            };
        }

        return new StatusCodeResult(500);
    }

    private static ValidationProblemDetails BuildValidationProblemDetails(ValidationError error)
    {
        return new ValidationProblemDetails(error.Errors)
        {
            Title = error.Message,
        };
    }

    private static ProblemDetails BuildProblemDetails(ErrorBase error)
    {
        return new ProblemDetails()
        {
            Title = error.Message,
        };
    }
}