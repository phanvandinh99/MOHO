using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ShipAddress).IsRequired();
            builder.Property(x => x.ShipEmail).IsRequired();
            builder.Property(x => x.ShipName).IsRequired();
            builder.Property(x => x.ShipPhoneNumber).IsRequired();
        }
    }
}
