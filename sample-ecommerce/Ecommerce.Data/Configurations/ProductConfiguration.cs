using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Stock).HasDefaultValue(0);
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.Quantity).HasDefaultValue(0);
            builder.Property(x => x.CategoryId).IsRequired();
        }
    }
}
