namespace Gateway.Models.Dtos;

public class OrderDetailsDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = "";
    public IEnumerable<OrderItemDto> Items { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "";
    public ShippingAddressDto ShippingAddress { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}