using AutoMapper;
using HA.Application.Clients.GetClientById.Responce;
using HA.Domain.Clients;

namespace HA.Application.Clients.GetClientById.Mapping;

/// <summary>
/// Профиль для маппинга Клиента.
/// </summary>
public class GetClientByIdDtoProfile : Profile
{
    public GetClientByIdDtoProfile()
    {
        CreateProjection<Client, GetClientByIdDto>();
    }
}

