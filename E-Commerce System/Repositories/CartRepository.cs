using Microsoft.EntityFrameworkCore;
using E_Commerce_System.Data;
using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Cart?> GetCartWithItemsAsync(string userId)
        => await _db.Carts
            .AsNoTracking()
            .Include(c => c.Items)
                .ThenInclude(ci => ci.ProductVariant)
                    .ThenInclude(v => v.Product)
                        .ThenInclude(p => p.Images.Where(i => i.IsMain))
            .FirstOrDefaultAsync(c => c.UserId == userId);
}
