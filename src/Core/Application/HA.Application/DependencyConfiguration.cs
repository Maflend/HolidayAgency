﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HA.Application;
public static class DependencyConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);

        return services;
    }
}