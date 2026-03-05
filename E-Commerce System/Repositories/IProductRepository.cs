using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public interface IProductRepository : IRepository<Product>
{
    /// <summary>Get product with all Variants and Images eagerly loaded.</summary>
    Task<Product?> GetWithVariantsAsync(int productId);

    /// <summary>Search products by name or description (case-insensitive), with pagination.</summary>
    Task<IEnumerable<Product>> SearchAsync(string keyword, int pageNumber, int pageSize);

    /// <summary>Filter active products by category, price range, size, and color.</summary>
    Task<IEnumerable<Product>> FilterAsync(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? size,
        string? color,
        int pageNumber,
        int pageSize);
}
