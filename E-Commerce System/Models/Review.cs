namespace E_Commerce_System.Models;

public class Review
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int Rating { get; set; }          // CHECK 1–5
    public string? Comment { get; set; }

    /// <summary>Admin must approve before the review is publicly visible — FR-REV-03.</summary>
    public bool IsApproved { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ApplicationUser User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
