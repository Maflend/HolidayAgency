using FluentValidation;
using HA.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HA.Application;
public static class DependencyConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(conf =>
        {
            conf
            .RegisterServicesFromAssembly(assembly)
            .AddOpenBehavior(typeof(ValidationPiplineBehavior<,>), ServiceLifetime.Scoped);
        });

        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
