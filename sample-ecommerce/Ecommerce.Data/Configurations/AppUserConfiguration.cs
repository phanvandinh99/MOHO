using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
        }
    }
}
