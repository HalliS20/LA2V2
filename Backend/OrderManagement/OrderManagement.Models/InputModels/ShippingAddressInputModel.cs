using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.InputModels;

// TODO: Attributes

public class ShippingAddressInputModel
{
    [Required]public string Street { get; set; } = null!;
    [Required]public string City { get; set; } = null!;
    [Required]public string State { get; set; } = null!;
    [Required]public string ZipCode { get; set; } = null!;
    [Required]public string Country { get; set; } = null!;
}