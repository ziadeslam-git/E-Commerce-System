using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Commerce_System.Models;

namespace E_Commerce_System.Data.EntityConfigurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Quantity)
            .IsRequired();

        builder.Property(ci => ci.PriceSnapshot)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Prevent duplicate variants in the same cart
        builder.HasIndex(ci => new { ci.CartId, ci.ProductVariantId })
            .IsUnique();

        // Check: Quantity must be > 0
        builder.ToTable(t => t.HasCheckConstraint("CK_CartItems_Quantity", "[Quantity] > 0"));

        builder.HasOne(ci => ci.ProductVariant)
            .WithMany(v => v.CartItems)
            .HasForeignKey(ci => ci.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
