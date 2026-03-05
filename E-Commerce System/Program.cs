using E_Commerce_System.Data;
using E_Commerce_System.Extensions;
using E_Commerce_System.Utilities.DBInitializer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ── Database ──────────────────────────────────────────────────────
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── Identity + JWT ────────────────────────────────────────────────
builder.Services.AddAppIdentity(builder.Configuration);

// ── Repositories + Unit of Work ───────────────────────────────────
builder.Services.AddRepositories();

// ── DB Initializer (Seed) ─────────────────────────────────────────
builder.Services.AddScoped<DBInitializer>();

// ── API ───────────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// ── Seed on Startup ───────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
    await initializer.SeedAsync();
}

// ── Middleware Pipeline ───────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Scalar UI at /scalar/v1
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
