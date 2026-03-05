namespace E_Commerce_System.Repositories;

/// <summary>
/// Unit of Work — groups all repositories and provides a single SaveChangesAsync.
/// Services use UoW so they never touch DbContext directly.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    ICartRepository Carts { get; }
    IDiscountRepository Discounts { get; }

    Task<int> SaveAsync();
}
