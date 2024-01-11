using AutoMapper;
using HA.Domain.Clients;

namespace HA.Application.UseCases.Clients.GetClientById.Mapping;

/// <summary>
/// Профиль для маппинга Клиента.
/// </summary>
public class GetClientByIdDtoProfile : Profile
{
    public GetClientByIdDtoProfile()
    {
        CreateProjection<Client, GetClientByIdResponse>();
    }
}

