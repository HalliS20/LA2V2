namespace OrderManagement.Models.Entities;

public class Order
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = "";
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ShippingAddress ShippingAddress { get; set; } = null!;
}