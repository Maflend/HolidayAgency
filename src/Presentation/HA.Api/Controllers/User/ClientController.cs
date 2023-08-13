using HA.Api.Dtos;
using HA.Api.Routes;
using Microsoft.AspNetCore.Mvc;

namespace HA.Api.Controllers.User;

[Route(UserRoute.ClientRoute.Base)]
[ApiController]
public class ClientController : ControllerBase
{
    public ClientController()
    {

    }

    [HttpGet]
    public IReadOnlyList<GetClientDto> GetClients()
    {
        return DataStorage.Clients
            .Select(c => new GetClientDto()
            {
                Id = c.Id,
                FullName = c.FullName,
                Phone = c.Phone,
            })
            .ToList();
    }

    [HttpGet(UserRoute.ClientRoute.GetById)]
    public ActionResult<GetClientDto> GetClient([FromRoute] Guid id)
    {
        var client = DataStorage.Clients.FirstOrDefault(c => c.Id == id);

        return client is null ? NotFound("Клиент не найден") : Ok(client);
    }
}
