using E_Commerce_System.Utilities;

namespace E_Commerce_System.Models;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }          // UNIQUE — one payment per order
    public decimal Amount { get; set; }
    public string Provider { get; set; } = SD.Provider_Stripe;

    /// <summary>Stripe Checkout Session ID or Charge ID — used for idempotency.</summary>
    public string? TransactionId { get; set; }

    public string Status { get; set; } = SD.PaymentStatus_Unpaid;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public Order Order { get; set; } = null!;
}
