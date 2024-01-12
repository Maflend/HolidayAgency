using HA.Application.Common.Mapping;
using HA.Domain.Clients;
using HA.Domain.Common;

namespace HA.Application.UseCases.Clients.GetClientById;

/// <summary>
/// Информация о клиенте.
/// </summary>
public class GetClientByIdResponse : IHasId, IMapFrom<Client>
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

