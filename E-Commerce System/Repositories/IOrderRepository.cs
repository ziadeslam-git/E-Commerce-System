using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    /// <summary>Get a single order with all navigation properties for order detail view.</summary>
    Task<Order?> GetOrderWithDetailsAsync(int orderId);

    /// <summary>Get all orders for a specific customer, newest first.</summary>
    Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
}
