using FluentResults.Extensions.AspNetCore;
using HA.Application.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers;

/// <summary>
/// Контроллер категорий.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Получить категории.
    /// </summary>
    /// <returns>Список категорий.</returns>
    [HttpGet]
    public Task<ActionResult> GetAsync()
    {
        return _sender.Send(new GetCategoriesQuery()).ToActionResult();
    }
}
