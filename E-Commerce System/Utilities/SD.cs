namespace E_Commerce_System.Utilities;

public static class SD
{
    // Roles
    public const string Role_Admin    = "Admin";
    public const string Role_Customer = "Customer";

    // Order Statuses
    public const string OrderStatus_Pending    = "Pending";
    public const string OrderStatus_Confirmed  = "Confirmed";
    public const string OrderStatus_Processing = "Processing";
    public const string OrderStatus_Shipped    = "Shipped";
    public const string OrderStatus_Delivered  = "Delivered";
    public const string OrderStatus_Cancelled  = "Cancelled";

    // Payment Statuses
    public const string PaymentStatus_Unpaid   = "Unpaid";
    public const string PaymentStatus_Paid     = "Paid";
    public const string PaymentStatus_Failed   = "Failed";
    public const string PaymentStatus_Refunded = "Refunded";

    // Shipment Statuses
    public const string ShipmentStatus_Pending        = "Pending";
    public const string ShipmentStatus_Shipped        = "Shipped";
    public const string ShipmentStatus_OutForDelivery = "OutForDelivery";
    public const string ShipmentStatus_Delivered      = "Delivered";

    // Discount Types
    public const string DiscountType_Percentage   = "Percentage";
    public const string DiscountType_FixedAmount  = "FixedAmount";

    // Payment Providers
    public const string Provider_Stripe = "Stripe";

    // Default Admin Seed
    public const string DefaultAdminEmail    = "admin@ecommerce.com";
    public const string DefaultAdminPassword = "Admin@123!";
    public const string DefaultAdminFullName = "System Admin";
}
