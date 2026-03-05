using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Commerce_System.Models;

namespace E_Commerce_System.Data.EntityConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.PublicId)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.IsMain)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(i => i.DisplayOrder)
            .IsRequired()
            .HasDefaultValue(0);
    }
}
