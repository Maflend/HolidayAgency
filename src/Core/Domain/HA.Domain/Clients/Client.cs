using HA.Domain.Common;

namespace HA.Domain.Clients;

/// <summary>
/// Клиент.
/// </summary>
public class Client : Entity
{
    #pragma warning disable CS8618
    private Client() { }
    #pragma warning restore CS8618

    public Client(string name, string surname, string phone, string? patronymic = null)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Phone = phone;
    }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; protected set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; protected set; }

    /// <summary>
    /// Телефон.
    /// </summary>
    public string Phone { get; protected set; }
}
