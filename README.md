# 🛍️ Smart E-Commerce System

> A modern, API-first e-commerce platform for selling custom T-shirts and gifts.
> Built with **ASP.NET Core (.NET 10)**, following **N-Tier Architecture** and industry best practices.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Features](#features)
- [Getting Started](#getting-started)
- [Environment Variables](#environment-variables)
- [API Endpoints](#api-endpoints)
- [Database](#database) 
---

## Overview

Smart E-Commerce System is a fully RESTful Web API for an online store. It supports product customization (size, color), multi-image products, cart management, Stripe payments, order tracking, wishlists, coupon codes, and a full admin dashboard — all through a clean, JSON-only API.

- 🚫 No Views — No Razor — No wwwroot
- ✅ JSON only
- ✅ JWT Authentication + Refresh Tokens
- ✅ Role-based Authorization (Admin / Customer)

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 10) |
| Language | C# 14 |
| ORM | Entity Framework Core (Code First) |
| Database | SQL Server |
| Authentication | ASP.NET Core Identity + JWT Bearer |
| Payment | Stripe |
| Image Storage | Cloudinary |
| Caching | Redis / In-Memory Cache |
| Validation | FluentValidation |
| Logging | Serilog |
| API Docs | Scalar / OpenAPI |

---

## Architecture

```
N-Tier (Layered) Architecture

HTTP Request
    ↓
[Controller]     →  Receive request, validate input, call service
    ↓
[Service]        →  Business logic, rules, calculations
    ↓
[Repository]     →  Data access only — no logic here
    ↓
[DbContext]      →  EF Core → SQL Server
    ↓
[DTO Mapping]    →  Entity → DTO (never expose raw entities)
    ↓
HTTP Response
```

---

## Project Structure

```
ECommerceAPI/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── ProductsController.cs
│   ├── CartController.cs
│   ├── OrdersController.cs
│   ├── PaymentController.cs
│   ├── ShippingController.cs
│   ├── ReviewsController.cs
│   ├── WishlistController.cs
│   ├── AddressController.cs
│   └── Admin/
│       ├── AdminProductsController.cs
│       ├── AdminOrdersController.cs
│       ├── AdminDiscountsController.cs
│       └── AdminDashboardController.cs
│
├── Data/
│   ├── EntityConfigurations/
│   ├── Migrations/
│   └── ApplicationDbContext.cs
│
├── Models/
│   ├── ApplicationUser.cs
│   ├── Product.cs
│   ├── ProductVariant.cs
│   ├── ProductImage.cs
│   ├── Category.cs
│   ├── Cart.cs
│   ├── CartItem.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Payment.cs
│   ├── Shipment.cs
│   ├── Address.cs
│   ├── WishlistItem.cs
│   ├── Discount.cs
│   └── Review.cs
│
├── DTOs/
│   ├── Auth/
│   ├── Products/
│   ├── Cart/
│   ├── Orders/
│   ├── Payment/
│   ├── Shipping/
│   ├── Reviews/
│   ├── Wishlist/
│   ├── Discounts/
│   └── Common/          ← PagedResultDto<T>
│
├── Repositories/
│   ├── IRepository.cs / Repository.cs
│   ├── IProductRepository.cs / ProductRepository.cs
│   ├── IOrderRepository.cs / OrderRepository.cs
│   ├── ICartRepository.cs / CartRepository.cs
│   ├── IDiscountRepository.cs / DiscountRepository.cs
│   └── IUnitOfWork.cs / UnitOfWork.cs
│
├── Services/
│   ├── IAuthService.cs / AuthService.cs
│   ├── IProductService.cs / ProductService.cs
│   ├── ICartService.cs / CartService.cs
│   ├── IOrderService.cs / OrderService.cs
│   ├── IPaymentService.cs / PaymentService.cs
│   ├── IShippingService.cs / ShippingService.cs
│   ├── IReviewService.cs / ReviewService.cs
│   ├── IWishlistService.cs / WishlistService.cs
│   ├── IDiscountService.cs / DiscountService.cs
│   └── IAddressService.cs / AddressService.cs
│
├── Utilities/
│   ├── DBInitializer/
│   ├── EmailSender.cs
│   ├── ImageUploadService.cs
│   ├── SD.cs
│   ├── StripeSettings.cs
│   └── CloudinarySettings.cs
│
├── Validations/
├── Extensions/
│   ├── ServiceExtensions.cs
│   ├── IdentityExtensions.cs
│   ├── SwaggerExtensions.cs
│   ├── CacheExtensions.cs
│   └── RateLimitExtensions.cs
│
├── Middleware/
│   ├── ExceptionHandlingMiddleware.cs
│   └── RequestLoggingMiddleware.cs
│
├── appsettings.json
├── GlobalUsings.cs
└── Program.cs
```

---

## Features

| Module | Features |
|---|---|
| **Auth** | Register, Login, JWT (5 min), Refresh Token (14 days), Password Reset, Email Verification |
| **Products** | Catalog, Variants (Size + Color), Multi-image, Search, Filter, Pagination |
| **Cart** | Add/Update/Remove, Price Snapshot, Coupon Support, Persistent Cart |
| **Orders** | Checkout, Status Lifecycle, Order History, Cancellation, Stock Restore |
| **Payment** | Stripe Checkout Sessions, Webhook Handling, Signature Verification |
| **Shipping** | Address Management, Shipment Tracking, Status Updates |
| **Reviews** | Star Ratings, Admin Moderation, Average Rating Calculation |
| **Wishlist** | Save Products, Move to Cart |
| **Discounts** | Coupon Codes (% or Fixed), Expiry, Usage Limits |
| **Admin** | Full Dashboard, Product/Order/User/Discount/Review Management |

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Stripe Account](https://stripe.com)
- [Cloudinary Account](https://cloudinary.com)

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/your-org/smart-ecommerce-api.git
cd smart-ecommerce-api

# 2. Restore dependencies
dotnet restore

# 3. Set up environment variables (see section below)

# 4. Apply database migrations
dotnet ef database update

# 5. Run the project
dotnet run
```

The API will be available at `https://localhost:5001`
Scalar UI (API docs) at `https://localhost:5001/scalar`

---

## Environment Variables

Create an `appsettings.Development.json` or set the following in your environment:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SmartECommerceDB;Trusted_Connection=True;"
  },
  "JwtSettings": {
    "Secret": "YOUR_SECRET_KEY_MIN_32_CHARS",
    "Issuer": "SmartECommerceAPI",
    "Audience": "SmartECommerceClient",
    "AccessTokenExpiryMinutes": 5,
    "RefreshTokenExpiryDays": 14
  },
  "StripeSettings": {
    "PublishableKey": "pk_test_...",
    "SecretKey": "sk_test_...",
    "WebhookSecret": "whsec_..."
  },
  "CloudinarySettings": {
    "CloudName": "your_cloud_name",
    "ApiKey": "your_api_key",
    "ApiSecret": "your_api_secret"
  },
  "EmailSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "Username": "your_email@gmail.com",
    "Password": "your_app_password"
  }
}
```

> ⚠️ Never commit real secrets to the repository. Use environment variables or a secrets manager in production.

---

## API Endpoints

### Auth
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| POST | `/api/auth/register` | ❌ | Register new account |
| POST | `/api/auth/login` | ❌ | Login, get JWT + refresh token |
| POST | `/api/auth/refresh-token` | ❌ | Renew access token |
| POST | `/api/auth/forgot-password` | ❌ | Send password reset email |
| POST | `/api/auth/reset-password` | ❌ | Reset password with token |

### Products
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| GET | `/api/products` | ❌ | Get paginated products with filters |
| GET | `/api/products/{id}` | ❌ | Get product details with variants |
| GET | `/api/categories` | ❌ | Get all categories |

### Cart
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| GET | `/api/cart` | ✅ Customer | Get cart with totals |
| POST | `/api/cart/items` | ✅ Customer | Add variant to cart |
| PUT | `/api/cart/items/{id}` | ✅ Customer | Update item quantity |
| DELETE | `/api/cart/items/{id}` | ✅ Customer | Remove item |
| POST | `/api/cart/apply-coupon` | ✅ Customer | Apply coupon code |

### Orders
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| POST | `/api/orders` | ✅ Customer | Place order from cart |
| GET | `/api/orders` | ✅ Customer | Get order history |
| GET | `/api/orders/{id}` | ✅ Customer | Get order details |
| PUT | `/api/orders/{id}/cancel` | ✅ Customer | Cancel order |

### Payment
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| POST | `/api/payment/create-session` | ✅ Customer | Create Stripe session |
| POST | `/api/payment/webhook` | Stripe Sig | Handle payment events |

### Wishlist
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| GET | `/api/wishlist` | ✅ Customer | Get wishlist |
| POST | `/api/wishlist` | ✅ Customer | Add to wishlist |
| DELETE | `/api/wishlist/{productId}` | ✅ Customer | Remove from wishlist |
| POST | `/api/wishlist/{productId}/move-to-cart` | ✅ Customer | Move to cart |

### Admin
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| GET | `/api/admin/dashboard` | ✅ Admin | Summary stats |
| POST | `/api/admin/products` | ✅ Admin | Create product |
| PUT | `/api/admin/products/{id}` | ✅ Admin | Update product |
| GET | `/api/admin/orders` | ✅ Admin | List all orders |
| PUT | `/api/admin/orders/{id}/status` | ✅ Admin | Update order status |
| POST | `/api/admin/discounts` | ✅ Admin | Create coupon |
| GET | `/api/admin/reviews` | ✅ Admin | Pending reviews |
| PUT | `/api/admin/reviews/{id}/approve` | ✅ Admin | Approve review |

---

## Database

**Code First** with EF Core. All entity configurations use Fluent API (`IEntityTypeConfiguration<T>`).

```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Rollback to a specific migration
dotnet ef database update MigrationName
```

On first run, `DBInitializer` automatically seeds:
- Default roles (`Admin`, `Customer`)
- Default admin account
- Sample categories and products

---



<p align="center">
  Built with ❤️ using ASP.NET Core
</p>
