using HA.Domain.ValueObjects;

namespace HA.Domain.Entities;

public class Client
{
    protected Client() { }
    public Client(FullName fullName, string phone)
    {
        FullName = fullName;
        Phone = phone;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public FullName FullName { get; protected set; }
    public string Phone { get; protected set; }
}
