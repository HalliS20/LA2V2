
namespace Gateway.Models.InputModels;

// TODO: Attributes

public class OrderInputModel
{
    public string EmailAddress { get; set; } = "";
    public IEnumerable<OderItemInputModel> Items { get; set; } = null!;
    public ShippingAddressInputModel ShippingAddress { get; set; } = null!;
}