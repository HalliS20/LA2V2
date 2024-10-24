using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.InputModels;

public class ProductInputModel
{
    [Required] public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    [Required] public decimal Price { get; set; }

    // Navigation properties
    // One-to-many relationship with Category
    [Required] public int CategoryId { get; set; }
}