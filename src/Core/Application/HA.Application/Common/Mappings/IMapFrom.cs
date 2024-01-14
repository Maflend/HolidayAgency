using AutoMapper;

namespace HA.Application.Common.Mappings;

/// <summary>
/// Смапить из типа.
/// </summary>
/// <typeparam name="T">Тип из которого нужно смапить.</typeparam>
public interface IMapFrom<T>
{
    /// <summary>
    /// Конфигурация маппинга.
    /// </summary>
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}
