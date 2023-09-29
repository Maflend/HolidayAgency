using FluentValidation;
using HA.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HA.Application;
public static class DependencyConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPiplineBehavior<,>));

        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
