namespace E_Commerce_System.Models;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductVariantId { get; set; }
    public int Quantity { get; set; }     // CHECK > 0

    /// <summary>
    /// Price captured at the moment the item was added to cart.
    /// Never affected by subsequent product price changes — BR-004.
    /// </summary>
    public decimal PriceSnapshot { get; set; }

    // Navigation Properties
    public Cart Cart { get; set; } = null!;
    public ProductVariant ProductVariant { get; set; } = null!;
}
