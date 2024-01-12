﻿using AutoMapper;
using System.Reflection;

namespace HA.Application.Common.Mapping;

public static class MappingExtensions
{
    public static void ApplyMappingsFromAssembly(this Profile profile, Assembly assembly)
    {
        var types = assembly
            .GetExportedTypes()
            .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

            methodInfo?.Invoke(instance, [profile]);
        }
    }
}