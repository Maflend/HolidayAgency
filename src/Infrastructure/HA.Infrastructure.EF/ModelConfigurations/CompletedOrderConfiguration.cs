using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HA.Infrastructure.EF.ModelConfigurations;
internal class CompletedOrderConfiguration : IEntityTypeConfiguration<CompletedOrder>
{
    public void Configure(EntityTypeBuilder<CompletedOrder> builder)
    {
    }
}
