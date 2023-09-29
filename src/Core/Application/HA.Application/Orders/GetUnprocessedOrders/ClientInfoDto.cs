namespace HA.Application.Orders.GetUnprocessedOrders;

public class ClientInfoDto
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string Surname { get;  set; }
    public string? Patronymic { get;  set; }
    public string Phone { get;  set; }
}
