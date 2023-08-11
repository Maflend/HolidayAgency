namespace HA.Domain.Models;
public class Order
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public DateTime EventDate { get; set; }
}
