using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.InputModels;

public class CategoryInputModel
{
    [Required]
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
}