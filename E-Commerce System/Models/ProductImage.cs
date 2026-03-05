namespace E_Commerce_System.Models;

public class ProductImage
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;   // Cloudinary URL
    public string PublicId { get; set; } = string.Empty;   // Cloudinary PublicId (for deletion)
    public bool IsMain { get; set; } = false;
    public int DisplayOrder { get; set; } = 0;

    // Navigation Properties
    public Product Product { get; set; } = null!;
}
