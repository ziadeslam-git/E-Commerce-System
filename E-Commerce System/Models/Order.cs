using E_Commerce_System.Utilities;

namespace E_Commerce_System.Models;

public class Order
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int AddressId { get; set; }

    // Lifecycle: Pending → Confirmed → Processing → Shipped → Delivered → Cancelled
    public string Status { get; set; } = SD.OrderStatus_Pending;

    // Payment: Unpaid → Paid | Failed | Refunded
    public string PaymentStatus { get; set; } = SD.PaymentStatus_Unpaid;

    public decimal Subtotal { get; set; }          // Before discount
    public decimal DiscountAmount { get; set; } = 0;
    public decimal TotalAmount { get; set; }       // After discount

    /// <summary>Coupon code applied to this order (one per order — BR-006).</summary>
    public string? CouponCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ApplicationUser User { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public ICollection<OrderItem> Items { get; set; } = [];
    public Payment? Payment { get; set; }
    public Shipment? Shipment { get; set; }
}
