using FluentResults.Extensions.AspNetCore;
using HA.Api.Endpoints.Orders.Dtos.Requests;
using HA.Application.Orders.ConfirmOrder;
using HA.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Orders;

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

    [HttpPut("{id}/confirm")]
    public Task<ActionResult> ConfirmAsync([FromRoute] Guid id, ConfirmOrderRequest confirmOrderRequest)
    {
        return _sender.Send(new ConfirmOrderCommand(
            id,
            confirmOrderRequest.EventPlan,
            confirmOrderRequest.Peoples,
            confirmOrderRequest.DiscountPerHour)).ToActionResult();
    }
}
