using HA.Domain.Common;

namespace HA.Domain.Models;

public class Client
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
}
