
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.InputModels;

// TODO: Attributes

public class OrderInputModel
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = "";
    [Required]
    public IEnumerable<OderItemInputModel> Items { get; set; } = null!;
    [Required]
    public ShippingAddressInputModel ShippingAddress { get; set; } = null!;
}