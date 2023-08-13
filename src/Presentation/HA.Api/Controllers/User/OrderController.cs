using HA.Api.Dtos;
using HA.Api.Routes;
using HA.Domain.Enums;
using HA.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HA.Api.Controllers.User;

[Route(UserRoute.OrderRoute.Base)]
[ApiController]
public class OrderController : ControllerBase
{
    public OrderController()
    {

    }

    [HttpGet]
    public ActionResult<List<GetOrderDto>> GetAll()
    {
        return Ok(DataStorage.Orders.Select(order => new GetOrderDto()
        {
            Id = order.Id,
            EventDate = order.EventDate,
            State = order.State,
            CountHourse = order.CountHours,
            Address = order.Address,
            Category = new OrderCategoryDto()
            {
                Id = order.Category.Id,
                Name = order.Category.Name
            },
            Client = new OrderClientDto()
            {
                Id = order.ClientId,
                FullName = order.Client.FullName,
                Phone = order.Client.Phone
            }
        }));
    }

    [HttpGet(UserRoute.OrderRoute.GetById)]
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
            EventDate = order.EventDate,
            State = order.State,
            CountHourse = order.CountHours,
            Address = order.Address,
            Category = new OrderCategoryDto()
            {
                Id = order.CategoryId,
                Name = order.Category.Name
            },
            Client = new OrderClientDto()
            {
                Id = order.ClientId,
                FullName = order.Client.FullName,
                Phone = order.Client.Phone
            }
        };

        return Ok(getOrderDto);
    }

    [HttpPost]
    public IActionResult CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var category = DataStorage.Categories.FirstOrDefault(c => c.Id == createOrderDto.CategoryId);

        if (category is null)
        {
            return NotFound("Категория не найдена");
        }

        var client = DataStorage.Clients.FirstOrDefault(c => c.Phone == createOrderDto.Phone);

        if (client is null)
        {
            client = new Client()
            {
                FullName = createOrderDto.FullName,
                Phone = createOrderDto.Phone,
                Id = Guid.NewGuid()
            };
        }

        var order = new Order()
        {
            Id = Guid.NewGuid(),
            EventDate = createOrderDto.EventDate,
            State = OrderState.New,
            Address = createOrderDto.Address,
            CountHours = createOrderDto.CountHourse,
            ClientId = client.Id,
            Client = client,
            CategoryId = createOrderDto.CategoryId,
            Category = category,
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
