using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Files;
using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace HA.Application.Dependencies.Persistence;
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
