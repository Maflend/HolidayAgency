using HA.Domain.ValueObjects;

namespace HA.Api.Dtos;

public class CreateOrderDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public DateTime EventDate { get; set; }
    public double CountHourse { get; set; }
    public string Address { get; set; }
    public int CountPeople { get; set; }

    public Guid CategoryId { get; set; }
}

public class GetNewOrderDto
{
    public Guid Id { get; set; }
    public DateTime EventDate { get; set; }
    public double CountHourse { get; set; }
    public string Address { get; set; }

    public OrderCategoryDto Category { get; set; }
    public OrderClientDto Client { get; set; }
}

public class OrderCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class OrderClientDto
{
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public string Phone { get; set; }
}

public class OrderPriceListDto
{

}