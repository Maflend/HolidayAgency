using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HA.Infrastructure.EF.ModelConfigurations;
internal class UnprocessedOrderConfiguration : IEntityTypeConfiguration<UnprocessedOrder>
{
    public void Configure(EntityTypeBuilder<UnprocessedOrder> builder)
    {
    }
}
