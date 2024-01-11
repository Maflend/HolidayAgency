using HA.ResultAsp.MinimalApi;
using Microsoft.Extensions.DependencyInjection;

namespace HA.ResultAsp;

public static class ResultsConfiguraiton
{
    public static IServiceCollection AddResults(this IServiceCollection services)
    {
        services.AddSingleton<MapperProvider>();

        return services;
    }
}
