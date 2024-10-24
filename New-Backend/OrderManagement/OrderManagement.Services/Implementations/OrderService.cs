using OrderManagement.Models.Dtos;
using OrderManagement.Models.InputModels;
using OrderManagement.Repository.Interfaces;
using OrderManagement.Services.Interfaces;

namespace OrderManagement.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public bool CreateNewOrder(OrderInputModel orderInputModel)
        {
            return _orderRepository.CreateNewOrder(orderInputModel);
        }

        public OrderDetailsDto? GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public IEnumerable<UserOrderDto> GetOrdersByUsername(string emailAddress)
        {
            return _orderRepository.GetOrdersByUsername(emailAddress);
        }
    }
}