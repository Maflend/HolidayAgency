using HA.Domain.Common;

namespace HA.Api.Dtos;

public class GetClientDto
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
}
