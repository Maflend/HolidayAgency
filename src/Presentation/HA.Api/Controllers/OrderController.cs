using HA.Api.Dtos;
using HA.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers;

//TODO: Две api. Один для клиента. Второй для админки.
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    public OrderController()
    {

    }

    public ActionResult<List<GetOrderDto>> GetByPage()
    {
        return Ok(DataStorage.Orders.Select(order => new GetOrderDto()
        {
            Id = order.Id,
            FullName = order.FullName,
            Phone = order.Phone,
            EventDate = order.EventDate,
            State = order.State,
            Category = new OrderCategoryDto()
            {
                Id = order.Category.Id,
                Name = order.Category.Name
            }
        }));
    }

    [HttpGet("{id}")]
    public ActionResult<GetOrderDto> GetById([FromRoute] Guid id)
    {
        var order = DataStorage.Orders.FirstOrDefault(o => o.Id == id);

        if (order is null)
        {
            return NotFound("Заказ не найден");
        }


        var getOrderDto = new GetOrderDto()
        {
            Id = id,
            FullName = order.FullName,
            Phone = order.Phone,
            EventDate = order.EventDate,
            State = order.State,
            Category = new OrderCategoryDto()
            {
                Id = order.Category.Id,
                Name = order.Category.Name
            }
        };

        return Ok(getOrderDto);
    }

    [HttpPost()]
    public IActionResult CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var category = DataStorage.Categories.FirstOrDefault(c => c.Id == createOrderDto.CategoryId);

        if (category is null)
        {
            return NotFound("Категория не найдена");
        }

        var order = new Order()
        {
            Id = Guid.NewGuid(),
            FullName = createOrderDto.FullName,
            Phone = createOrderDto.Phone,
            EventDate = createOrderDto.EventDate,
            CategoryId = createOrderDto.CategoryId,
            Category = category,
            State = OrderState.New,
            Address = createOrderDto.Address,
            CountHours = createOrderDto.CountHourse
        };

        DataStorage.Orders.Add(order);

        return Ok();
    }

    [HttpPut("{id}/state")]
    public IActionResult ChangeState([FromRoute] Guid id, ChangeOrderStateDto changeOrderStateDto)
    {
        var order = DataStorage.Orders.FirstOrDefault(o => o.Id == id);

        if (order is null)
        {
            return NotFound("Заказ не найден");
        }

        //TODO: State machine.

        order.State = (order.State, changeOrderStateDto.State) switch
        {
            (OrderState.New, OrderState.Confirmed) => order.State = changeOrderStateDto.State,
            (OrderState.Confirmed, OrderState.Completed) => order.State = changeOrderStateDto.State,
            _ => throw new Exception("Invalid")
        };

        return Ok();
    }
}
