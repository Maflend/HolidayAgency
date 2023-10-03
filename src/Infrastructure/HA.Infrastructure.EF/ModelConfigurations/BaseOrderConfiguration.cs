using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HA.Infrastructure.EF.ModelConfigurations;

internal class BaseOrderConfiguration : IEntityTypeConfiguration<BaseOrder>
{
    public void Configure(EntityTypeBuilder<BaseOrder> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(e => e.Id);

        builder.HasOne(order => order.Category)
            .WithMany()
            .HasForeignKey(order => order.CategoryId);

        builder.HasOne(order => order.Client)
            .WithMany()
            .HasForeignKey(order => order.ClientId);

        builder.Property(e => e.Address).IsRequired();
        builder.Property(e => e.CountHours).IsRequired();
        builder.Property(e => e.EventDate).IsRequired();
        builder.Property(e => e.CountPeople).IsRequired();
    }
}