namespace HA.Application.Orders.GetUnprocessedOrders;

public class GetOrderUnprocessedDto
{
    public Guid Id { get; set; }
    public DateTime EventDate { get;  set; }
    public string Address { get;  set; } 
    public double CountHours { get;  set; }
    public int CountPeople { get;  set; }

    public ClientInfoDto Client { get; set; }

    public string CategoryName { get; set; }

}
