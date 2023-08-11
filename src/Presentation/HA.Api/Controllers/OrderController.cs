using HA.Api.Dtos;
using HA.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    public OrderController()
    {
        
    }

    public void CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            FirstName = createOrderDto.FirstName,
            LastName = createOrderDto.LastName,
            MiddleName = createOrderDto.MiddleName,
            Phone = createOrderDto.Phone,
            EventDate = createOrderDto.EventDate
        };

        DataStorage.Orders.Add(order);
    }
}
