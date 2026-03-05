using Microsoft.EntityFrameworkCore;
using E_Commerce_System.Data;
using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
        => await _db.Orders
            .AsNoTracking()
            .Include(o => o.Items)
                .ThenInclude(oi => oi.ProductVariant)
            .Include(o => o.Address)
            .Include(o => o.Payment)
            .Include(o => o.Shipment)
            .FirstOrDefaultAsync(o => o.Id == orderId);

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
        => await _db.Orders
            .AsNoTracking()
            .Where(o => o.UserId == userId)
            .Include(o => o.Items)
            .Include(o => o.Payment)
            .Include(o => o.Shipment)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();
}
