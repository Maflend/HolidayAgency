using HA.Domain.Common;

namespace HA.Domain.Entities;

public class Client : Entity
{
    private Client() { }

    public Client(string name, string surname, string phone, string? patronymic = null)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Phone = phone;
    }

    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string? Patronymic { get; protected set; }
    public string Phone { get; protected set; }
}
