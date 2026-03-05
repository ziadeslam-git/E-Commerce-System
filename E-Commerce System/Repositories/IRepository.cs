using System.Linq.Expressions;

namespace E_Commerce_System.Repositories;

/// <summary>
/// Generic repository interface providing standard CRUD + query operations.
/// All read operations use AsNoTracking by default for performance.
/// </summary>
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        string? includeProperties = null,
        bool tracked = false);

    Task<T?> GetAsync(
        Expression<Func<T, bool>> filter,
        string? includeProperties = null,
        bool tracked = false);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
