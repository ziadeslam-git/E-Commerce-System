using Microsoft.AspNetCore.Identity;
using E_Commerce_System.Data;
using E_Commerce_System.Models;
using E_Commerce_System.Utilities;

namespace E_Commerce_System.Utilities.DBInitializer;

public class DBInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _db;

    public DBInitializer(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext db)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
    }

    public async Task SeedAsync()
    {
        // ── 1. Roles ─────────────────────────────────────────────
        await SeedRolesAsync();

        // ── 2. Admin User ─────────────────────────────────────────
        await SeedAdminUserAsync();

        // ── 3. Sample Categories ──────────────────────────────────
        await SeedCategoriesAsync();

        // ── 4. Sample Products ────────────────────────────────────
        await SeedProductsAsync();
    }

    // ─────────────────────────────────────────────────────────────
    private async Task SeedRolesAsync()
    {
        string[] roles = [SD.Role_Admin, SD.Role_Customer];

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    private async Task SeedAdminUserAsync()
    {
        var admin = await _userManager.FindByEmailAsync(SD.DefaultAdminEmail);
        if (admin is not null) return;

        var newAdmin = new ApplicationUser
        {
            FullName = SD.DefaultAdminFullName,
            UserName = SD.DefaultAdminEmail,
            Email = SD.DefaultAdminEmail,
            NormalizedEmail = SD.DefaultAdminEmail.ToUpper(),
            EmailConfirmed = true,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(newAdmin, SD.DefaultAdminPassword);
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(newAdmin, SD.Role_Admin);
    }

    private async Task SeedCategoriesAsync()
    {
        if (_db.Categories.Any()) return;

        var tshirts = new Category { Name = "T-Shirts", Slug = "tshirts" };
        var gifts = new Category { Name = "Gifts", Slug = "gifts" };

        _db.Categories.AddRange(tshirts, gifts);
        await _db.SaveChangesAsync();

        // Subcategories
        _db.Categories.AddRange(
            new Category { Name = "Men T-Shirts", Slug = "men-tshirts", ParentCategoryId = tshirts.Id },
            new Category { Name = "Women T-Shirts", Slug = "women-tshirts", ParentCategoryId = tshirts.Id },
            new Category { Name = "Custom Gifts", Slug = "custom-gifts", ParentCategoryId = gifts.Id }
        );
        await _db.SaveChangesAsync();
    }

    private async Task SeedProductsAsync()
    {
        if (_db.Products.Any()) return;

        var menCategoryId = _db.Categories.First(c => c.Slug == "men-tshirts").Id;

        var product = new Product
        {
            Name = "Classic Cotton T-Shirt",
            Description = "Premium 100% cotton t-shirt — available in multiple sizes and colors.",
            BasePrice = 99.99m,
            CategoryId = menCategoryId,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        _db.ProductVariants.AddRange(
            new ProductVariant
            {
                ProductId = product.Id,
                Size = "M",
                Color = "White",
                SKU = "TSH-M-WHT-001",
                Price = 99.99m,
                Stock = 50,
                IsActive = true
            },
            new ProductVariant
            {
                ProductId = product.Id,
                Size = "L",
                Color = "Black",
                SKU = "TSH-L-BLK-001",
                Price = 99.99m,
                Stock = 30,
                IsActive = true
            }
        );

        await _db.SaveChangesAsync();
    }
}
