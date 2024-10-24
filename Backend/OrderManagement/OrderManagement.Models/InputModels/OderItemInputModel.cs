using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.InputModels;

public class OderItemInputModel
{
    [Required]public int ProductId { get; set; }
    [Required]public int Quantity { get; set; }
}