using FluentValidation;
using HA.Application.Common.Models.Errors;
using HA.ResultDomain;
using MediatR;

namespace HA.Application.Common.Behaviors;

public class ValidationPiplineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : ResultBase, new()
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPiplineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(request)));

        var errorsDictionary = validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (errorsDictionary.Count != 0)
        {
            var result = new TResponse
            {
                Error = new ValidationError(errorsDictionary)
            };

            return result;
        }

        return await next();
    }
}
