using E_Commerce_System.Repositories;

namespace E_Commerce_System.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Register all Repositories and Unit of Work.
    /// Future Services (AuthService, ProductService, etc.) will be added here too.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Unit of Work (aggregates all repos)
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Specific Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();

        return services;
    }
}
