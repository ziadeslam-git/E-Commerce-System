using E_Commerce_System.Utilities;

namespace E_Commerce_System.Models;

public class Shipment
{
    public int Id { get; set; }
    public int OrderId { get; set; }   // UNIQUE — one shipment per order
    public string? TrackingNumber { get; set; }
    public string? Carrier { get; set; }
    public string Status { get; set; } = SD.ShipmentStatus_Pending;
    public DateOnly? EstimatedDelivery { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }

    // Navigation Properties
    public Order Order { get; set; } = null!;
}
