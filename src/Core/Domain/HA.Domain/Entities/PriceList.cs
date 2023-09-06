namespace HA.Domain.Entities;

public class PriceList
{
    public Guid Id { get; set; }
    public decimal PriceOfHourse { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
