using FluentResults.Extensions.AspNetCore;
using HA.Application.Orders.CreateOrder;
using HA.Application.Orders.GetUnprocessedOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers;

/// <summary>
/// Контроллер заказов.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }
     
    /// <summary>
    /// Создать.
    /// </summary>
    /// <param name="createOrderCommand">Информация о заказе.</param>
    /// <returns>Идентификатор.</returns>
    [HttpPost]
    public Task<ActionResult> Create(CreateOrderCommand createOrderCommand)
    {
        return _sender.Send(createOrderCommand).ToActionResult();
    }

    /// <summary>
    /// Получить необработанные заказы.
    /// </summary>
    /// <returns>Список необработанных заказов.</returns>
    [HttpGet("unprocessed")]
    public Task<ActionResult> GetUnprocessedOrdersAsync()
    {
        return _sender.Send(new GetUnprocessedOrdersQuery()).ToActionResult();
    }
}
