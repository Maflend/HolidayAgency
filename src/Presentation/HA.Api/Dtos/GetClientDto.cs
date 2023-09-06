using HA.Domain.ValueObjects;

namespace HA.Api.Dtos;

public class GetClientDto
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
}
