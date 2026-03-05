using Microsoft.EntityFrameworkCore;
using E_Commerce_System.Data;
using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public class DiscountRepository : Repository<Discount>, IDiscountRepository
{
    public DiscountRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Discount?> GetByCodeAsync(string couponCode)
        => await _db.Discounts
            .AsNoTracking()
            .FirstOrDefaultAsync(d =>
                d.CouponCode == couponCode &&
                d.IsActive &&
                (d.ExpiresAt == null || d.ExpiresAt > DateTime.UtcNow) &&
                (d.UsageLimit == null || d.UsageCount < d.UsageLimit));
}
