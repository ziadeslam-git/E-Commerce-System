namespace E_Commerce_System.Models;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;  // UNIQUE — one cart per user
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ApplicationUser User { get; set; } = null!;
    public ICollection<CartItem> Items { get; set; } = [];
}
