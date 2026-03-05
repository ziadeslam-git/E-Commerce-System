namespace E_Commerce_System.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    /// <summary>
    /// FK to ProductVariant — kept with NO ACTION on delete to preserve order history
    /// even if the variant is later deactivated or deleted.
    /// </summary>
    public int ProductVariantId { get; set; }

    // Snapshots — frozen at order time, never affected by future product changes
    public string ProductName { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public int Quantity { get; set; }        // CHECK > 0
    public decimal UnitPrice { get; set; }   // Price at order time
    public decimal Subtotal { get; set; }    // UnitPrice × Quantity

    // Navigation Properties
    public Order Order { get; set; } = null!;
    public ProductVariant ProductVariant { get; set; } = null!;
}
