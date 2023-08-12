namespace HA.Domain.Models;
public class Order
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
    public DateTime EventDate { get; set; }
    public double CountHours { get; set; }
    public string Address { get; set; }
    public OrderState State { get; set; }


    public EventPlan? EventPlan { get; set; }

    public Guid PriceListId { get; set; }
    public PriceList PriceList { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}

public class EventPlan
{
    public string Description { get; set; }
}

public class PriceList
{
    public Guid Id { get; set; }
    public decimal PriceOfHourse { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}

public enum OrderState
{
    None = 0,
    New = 1,
    Confirmed = 2,
    Completed = 3
}

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}

public record FullName(string FirstName, string LastName, string Patronymic);