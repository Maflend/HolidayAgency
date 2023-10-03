using HA.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HA.Infrastructure.EF.ModelConfigurations;
internal class ConfirmedOrderConfiguration : IEntityTypeConfiguration<ConfirmedOrder>
{
    public void Configure(EntityTypeBuilder<ConfirmedOrder> builder)
    {
    }
}
