using HA.Api.Dtos;
using HA.Domain.Common;
using HA.Domain.Models;
using HA.Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers.User;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    public OrderController()
    {

    }

    // Потребуется апи для отображения завершенных заказов на странице для пользователей (не для админа, у админа будет отображаться конфиденциальная информация)

    //[HttpGet]
    //public ActionResult<List<GetNewOrderDto>> GetAll()
    //{
    //    return Ok(DataStorage.Orders.Select(order => new GetNewOrderDto()
    //    {
    //        Id = order.Id,
    //        EventDate = order.EventDate,
    //        CountHourse = order.CountHours,
    //        Address = order.Address,
    //        Category = new OrderCategoryDto()
    //        {
    //            Id = order.Category.Id,
    //            Name = order.Category.Name
    //        },
    //        Client = new OrderClientDto()
    //        {
    //            Id = order.ClientId,
    //            FullName = order.Client.FullName,
    //            Phone = order.Client.Phone
    //        }
    //    }));
    //}

    //Пользователь может зайти на сайт, и если захочет посмотреть свои заказы то он вводить номер телефона/почту и после этого отображаются его заказы.
    //Видимо будет добавлена аутентификация. А еще пизже будет внедрить аутентификацию через ВК, гугл, маил

    //[HttpGet("new/{id}")]
    //public ActionResult<GetNewOrderDto> GetById([FromRoute] Guid id)
    //{
    //    var order = DataStorage.NewOrders.FirstOrDefault(o => o.Id == id);

    //    if (order is null)
    //    {
    //        return NotFound("Заказ не найден");
    //    }

    //    var getOrderDto = new GetNewOrderDto()
    //    {
    //        Id = id,
    //        EventDate = order.EventDate,
    //        CountHourse = order.CountHours,
    //        Address = order.Address,
    //        Category = new OrderCategoryDto()
    //        {
    //            Id = order.CategoryId,
    //            Name = order.Category.Name
    //        },
    //        Client = new OrderClientDto()
    //        {
    //            Id = order.ClientId,
    //            FullName = order.Client.FullName,
    //            Phone = order.Client.Phone
    //        }
    //    };

    //    return Ok(getOrderDto);
    //}

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
            client = new Client(new FullName(createOrderDto.FirstName, createOrderDto.LastName, createOrderDto.Patronymic), createOrderDto.Phone);
        }

        var priceList = new PriceList();

        var order = new NewOrder(
            category,
            priceList,
            client,
            createOrderDto.EventDate,
            createOrderDto.Address,
            createOrderDto.CountHourse,
            createOrderDto.CountPeople);

        DataStorage.NewOrders.Add(order);

        return Ok();
    }

    //Так как состояние теперь у заказа нет, то этот апи не нужен. Но пусть лежит и глаз мазолит.

    //[HttpPut("{id}/state")]
    //public IActionResult ChangeState([FromRoute] Guid id, ChangeOrderStateDto changeOrderStateDto)
    //{
    //    var order = DataStorage.Orders.FirstOrDefault(o => o.Id == id);

    //    if (order is null)
    //    {
    //        return NotFound("Заказ не найден");
    //    }

    //    //TODO: State machine.

    //    order.State = (order.State, changeOrderStateDto.State) switch
    //    {
    //        (OrderState.New, OrderState.Confirmed) => order.State = changeOrderStateDto.State,
    //        (OrderState.Confirmed, OrderState.Completed) => order.State = changeOrderStateDto.State,
    //        _ => throw new Exception("Invalid")
    //    };

    //    return Ok();
    //}
}
