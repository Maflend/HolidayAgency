namespace HA.Application.Orders.GetUnprocessedOrderById.Responce;

/// <summary>
/// Информация о клиенте.
/// </summary>
public class ClientInfoDto
{
    /// <summary>
    /// Индентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Phone { get; set; }
}