using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    /// <summary>Get the user's cart with all items, variant details, and product info.</summary>
    Task<Cart?> GetCartWithItemsAsync(string userId);
}
