namespace E_Commerce_System.Models;

public class Address
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;

    // Navigation Properties
    public ApplicationUser User { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = [];
}
