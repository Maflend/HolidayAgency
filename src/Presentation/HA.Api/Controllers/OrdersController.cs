using FluentResults.Extensions.AspNetCore;
using HA.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public Task<ActionResult> CreateAsync(CreateOrderCommand createOrderCommand)
    {
        return _sender.Send(createOrderCommand).ToActionResult();
    }
}
