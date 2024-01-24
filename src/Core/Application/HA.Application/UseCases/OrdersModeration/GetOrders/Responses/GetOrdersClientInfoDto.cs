using HA.Application.Common.Mappings;
using HA.Domain.Clients;

namespace HA.Application.UseCases.OrdersModeration.GetOrders.Responses;

/// <summary>
/// Информация о клиенте.
/// </summary>
public class GetOrdersClientInfoDto : IMapFrom<Client>
{
    /// <summary>
    /// Индентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Phone { get; set; } = null!;
}
