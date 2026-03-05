using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Commerce_System.Models;

namespace E_Commerce_System.Data.EntityConfigurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Size)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(v => v.Color)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.SKU)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(v => v.Stock)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(v => v.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Optimistic Concurrency — maps to SQL rowversion
        builder.Property(v => v.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        // SKU must be globally unique
        builder.HasIndex(v => v.SKU)
            .IsUnique();

        // A product cannot have two variants with the same size + color combination
        builder.HasIndex(v => new { v.ProductId, v.Size, v.Color })
            .IsUnique();

        // Check: Stock must be >= 0
        builder.ToTable(t => t.HasCheckConstraint("CK_ProductVariants_Stock", "[Stock] >= 0"));
    }
}
