using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);

            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);

            builder.Property(x => x.Content).IsRequired();

            builder.Property(x => x.Image).HasMaxLength(500);

            builder.Property(x => x.PublishDate).IsRequired();

            builder.Property(x => x.IsPublished).HasDefaultValue(false);

            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.UpdatedAt).IsRequired();
        }
    }
}
