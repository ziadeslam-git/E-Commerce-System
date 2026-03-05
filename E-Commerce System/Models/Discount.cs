using E_Commerce_System.Utilities;

namespace E_Commerce_System.Models;

public class Discount
{
    public int Id { get; set; }
    public string CouponCode { get; set; } = string.Empty;  // UNIQUE — e.g. SUMMER25

    /// <summary>SD.DiscountType_Percentage or SD.DiscountType_FixedAmount</summary>
    public string Type { get; set; } = SD.DiscountType_Percentage;

    /// <summary>25 = 25% off OR $25 off, depending on Type.</summary>
    public decimal Value { get; set; }

    public decimal? MinimumOrderAmount { get; set; }  // Minimum cart total to apply
    public int? UsageLimit { get; set; }              // NULL = unlimited
    public int UsageCount { get; set; } = 0;
    public DateTime? ExpiresAt { get; set; }          // NULL = no expiry
    public bool IsActive { get; set; } = true;
}
