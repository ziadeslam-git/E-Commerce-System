namespace E_Commerce_System.Models;

public class ProductVariant
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Size { get; set; } = string.Empty;   // XS / S / M / L / XL / XXL
    public string Color { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;   // Unique
    public decimal Price { get; set; }                 // Can override BasePrice
    public int Stock { get; set; } = 0;               // CHECK >= 0
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Optimistic Concurrency token — prevents race conditions on Stock updates.
    /// EF Core maps [Timestamp] to SQL rowversion automatically.
    /// </summary>
    public byte[] RowVersion { get; set; } = [];

    // Navigation Properties
    public Product Product { get; set; } = null!;
    public ICollection<CartItem> CartItems { get; set; } = [];
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
