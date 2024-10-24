namespace ProductCatalog.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }

    // Navigation properties
    // One-to-many relationship with Category

    public int CategoryId { get; set; }

}