using HA.ResultAsp.MinimalApi.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace HA.ResultAsp.MinimalApi;

public class MapperProvider
{
    private readonly static IResultMapper _default = new DefaultResultMapper();

    public MapperProvider(IServiceProvider serviceProvider)
    {
        Mapper = serviceProvider.GetService<IResultMapper>() ?? _default; // НЕ ВЫЗ КОНСТРУКТОР ТАК КАК ВЗАИМОДЕЙСТВУЮ С СТАТИК СВОЙСТВОМ
    }

    public static IResultMapper Mapper { get; private set; } = _default;
}
