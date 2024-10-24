using OrderManagement.Models.Dtos;
using OrderManagement.Models.InputModels;

namespace OrderManagement.Services.Interfaces;

public interface IOrderService
{
    public IEnumerable<OrderDto> GetAllOrders();
    public OrderDetailsDto? GetOrderById(int id);
    public IEnumerable<UserOrderDto> GetOrdersByUsername(string emailAddress);
    public bool CreateNewOrder(OrderInputModel orderInputModel);
}