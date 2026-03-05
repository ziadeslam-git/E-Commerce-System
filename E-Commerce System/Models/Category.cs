namespace E_Commerce_System.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    // Self-referencing hierarchy
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    // Navigation Properties
    public ICollection<Category> SubCategories { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}
