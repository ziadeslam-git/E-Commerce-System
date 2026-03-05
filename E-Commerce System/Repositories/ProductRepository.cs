using Microsoft.EntityFrameworkCore;
using E_Commerce_System.Data;
using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Product?> GetWithVariantsAsync(int productId)
        => await _db.Products
            .AsNoTracking()
            .Include(p => p.Variants)
            .Include(p => p.Images)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId);

    public async Task<IEnumerable<Product>> SearchAsync(string keyword, int pageNumber, int pageSize)
    {
        var lower = keyword.ToLower();
        return await _db.Products
            .AsNoTracking()
            .Where(p => p.IsActive &&
                        (p.Name.ToLower().Contains(lower) ||
                         (p.Description != null && p.Description.ToLower().Contains(lower))))
            .Include(p => p.Images.Where(i => i.IsMain))
            .OrderBy(p => p.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> FilterAsync(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? size,
        string? color,
        int pageNumber,
        int pageSize)
    {
        var query = _db.Products
            .AsNoTracking()
            .Where(p => p.IsActive)
            .Include(p => p.Variants)
            .Include(p => p.Images.Where(i => i.IsMain))
            .AsQueryable();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (minPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price >= minPrice.Value));

        if (maxPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price <= maxPrice.Value));

        if (!string.IsNullOrWhiteSpace(size))
            query = query.Where(p => p.Variants.Any(v => v.Size == size && v.IsActive && v.Stock > 0));

        if (!string.IsNullOrWhiteSpace(color))
            query = query.Where(p => p.Variants.Any(v => v.Color == color && v.IsActive && v.Stock > 0));

        return await query
            .OrderBy(p => p.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
