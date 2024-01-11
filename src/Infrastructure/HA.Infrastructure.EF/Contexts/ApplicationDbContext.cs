using Microsoft.EntityFrameworkCore;
using System.Reflection;
using HA.Application.Dependencies.Persistence;
using HA.Domain.Orders;
using HA.Domain.Categories;
using HA.Domain.Clients;
using HA.Domain.Files;

namespace HA.Infrastructure.EF.Contexts;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public ApplicationDbContext() { }

    public DbSet<UnprocessedOrder> UnprocessedOrders { get; set; }
    public DbSet<ConfirmedOrder> ConfirmedOrders { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<EventFile> EventFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
