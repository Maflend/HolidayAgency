using HA.Domain.Entities;
using HA.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Common.Persistence;
public interface IApplicationDbContext
{
    public DbSet<UnprocessedOrder> UnprocessedOrders { get; set; }
    public DbSet<ConfirmedOrder> ConfirmedOrders { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<EventFile> EventFiles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
