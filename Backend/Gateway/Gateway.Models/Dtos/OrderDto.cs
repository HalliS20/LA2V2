namespace Gateway.Models.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = "";
    public decimal TolalAmount { get; set; }
    public string Status { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}