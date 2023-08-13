using HA.Domain.Enums;

namespace HA.Domain.Models;
public class Order
{
    public Guid Id { get; set; }
    public DateTime EventDate { get; set; }
    public double CountHours { get; set; }
    public string Address { get; set; }
    public OrderState State { get; set; }


    public string? EventPlan { get; set; }

    public Guid PriceListId { get; set; }
    public PriceList PriceList { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
