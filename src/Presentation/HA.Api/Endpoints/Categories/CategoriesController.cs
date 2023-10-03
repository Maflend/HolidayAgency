using FluentResults.Extensions.AspNetCore;
using HA.Application.Categories.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Endpoints.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public Task<ActionResult> CreateAsync(CreateCategoryCommand createCategoryCommand)
    {
        return _sender.Send(createCategoryCommand).ToActionResult();
    }
}
