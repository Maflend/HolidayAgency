namespace HA.Domain.Models.Orders;

public abstract class BaseOrder
{
    public Guid Id { get; set; }
    public DateTime EventDate { get; set; }
    public string Address { get; set; }
    public double CountHours { get; set; }
    public int CountPeople { get; set; }

    public Guid PriceListId { get; set; }
    public PriceList PriceList { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
