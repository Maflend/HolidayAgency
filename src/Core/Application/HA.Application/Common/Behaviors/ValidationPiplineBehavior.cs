using FluentValidation;
using HA.Application.Common.Results;
using MediatR;

namespace HA.Application.Common.Behaviors;

public class ValidationPiplineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators) 
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : IResultBase, new()
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
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
            var requestName = typeof(TRequest).Name;
            var name = requestName.EndsWith("Query") ?
                requestName[..requestName.IndexOf("Query")] :
                requestName[..requestName.IndexOf("Command")];

            var result = new TResponse
            {
                Error = new Error(name + ".Invalid", errorsDictionary)
            };

            return result;
        }

        return await next();
    }
}
