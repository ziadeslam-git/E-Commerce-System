using E_Commerce_System.Models;

namespace E_Commerce_System.Repositories;

public interface IDiscountRepository : IRepository<Discount>
{
    /// <summary>Get an active, non-expired discount by coupon code.</summary>
    Task<Discount?> GetByCodeAsync(string couponCode);
}
