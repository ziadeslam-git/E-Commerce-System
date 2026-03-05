using E_Commerce_System.Data;

namespace E_Commerce_System.Repositories;

/// <summary>
/// Unit of Work implementation. Repos are lazily initialized on first access.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    private IProductRepository? _products;
    private IOrderRepository? _orders;
    private ICartRepository? _carts;
    private IDiscountRepository? _discounts;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }

    public IProductRepository Products
        => _products ??= new ProductRepository(_db);

    public IOrderRepository Orders
        => _orders ??= new OrderRepository(_db);

    public ICartRepository Carts
        => _carts ??= new CartRepository(_db);

    public IDiscountRepository Discounts
        => _discounts ??= new DiscountRepository(_db);

    public async Task<int> SaveAsync()
        => await _db.SaveChangesAsync();

    public void Dispose()
        => _db.Dispose();
}
