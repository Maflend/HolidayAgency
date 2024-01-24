using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HA.Infrastructure.EF.ModelConfigurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(e => e.Id);

        builder.HasOne(order => order.Category)
            .WithMany()
            .HasForeignKey(order => order.CategoryId);

        builder.HasOne(order => order.Client)
            .WithMany()
            .HasForeignKey(order => order.ClientId);

        builder.Property(e => e.EndDate).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
    }
}