namespace HA.Api.Dtos;

public class CreateOrderDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public DateTime EventDate { get; set; }
}
