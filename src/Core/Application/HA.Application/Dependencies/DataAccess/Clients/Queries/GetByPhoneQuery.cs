using HA.Domain.Clients;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Dependencies.DataAccess.Clients.Queries;

internal static class GetByPhoneQuery
{
    /// <summary>
    /// Получить клиента по номеру телефона.
    /// </summary>
    public static Task<Client?> GetByPhoneAsync(
        this IQueryable<Client> clients,
        string phone,
        CancellationToken cancellationToken = default)
    {
        return clients.SingleOrDefaultAsync(c => c.Phone == phone, cancellationToken);
    }
}
