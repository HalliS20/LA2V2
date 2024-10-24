namespace Gateway.Models.Dtos;

public class UserOrderDto
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}