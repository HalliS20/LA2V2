using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Dtos;
using OrderManagement.Models.Entities;
using OrderManagement.Models.InputModels;
using OrderManagement.Repository.Interfaces;
using Orders.API.Contexts;

namespace OrderManagement.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersApiContext _ordersDbContext;

        public OrderRepository(OrdersApiContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            return _ordersDbContext.Orders.Select(o => new OrderDto
            {
                Id = o.Id,
                EmailAddress = o.EmailAddress,
                TolalAmount = o.TotalAmount,
                Status = o.Status,
                CreatedAt = o.CreatedAt
            });
        }

        public bool CreateNewOrder(OrderInputModel orderInputModel)
        {
            decimal totalAmount = 0;

            foreach (var item in orderInputModel.Items)
            {
                if (!_ordersDbContext.Products.Any(p => p.Id == item.ProductId))
                {
                    return false;
                }

                foreach (var product in _ordersDbContext.Products)
                {
                    if (product.Id == item.ProductId)
                    {
                        totalAmount += product.Price * item.Quantity;
                    }
                }
            }

            Order order = new Order
            {
                EmailAddress = orderInputModel.EmailAddress,
                TotalAmount = totalAmount,
                ShippingAddress = new ShippingAddress
                {
                    City = orderInputModel.ShippingAddress.City,
                    Street = orderInputModel.ShippingAddress.Street,
                    State = orderInputModel.ShippingAddress.State,
                    ZipCode = orderInputModel.ShippingAddress.ZipCode,
                    Country = orderInputModel.ShippingAddress.Country
                },
                CreatedAt = DateTime.UtcNow,
                Items = orderInputModel.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                }).ToList()
            };

            _ordersDbContext.Orders.Add(order);
            _ordersDbContext.SaveChanges();

            return true;
        }

        public OrderDetailsDto? GetOrderById(int id)
        {
            var order = _ordersDbContext.Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            return new OrderDetailsDto
            {
                Id = order.Id,
                EmailAddress = order.EmailAddress,
                Items = order.Items.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = _ordersDbContext.Products.FirstOrDefault(p => p.Id == i.ProductId).Name,
                    Quantity = i.Quantity,
                    UnitPrice = _ordersDbContext.Products.FirstOrDefault(p => p.Id == i.ProductId).Price
                }),
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                ShippingAddress = new ShippingAddressDto
                {
                    Street = order.ShippingAddress.Street,
                    City = order.ShippingAddress.City,
                    State = order.ShippingAddress.State,
                    ZipCode = order.ShippingAddress.ZipCode,
                    Country = order.ShippingAddress.Country
                },
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt
            };
        }

        public IEnumerable<UserOrderDto> GetOrdersByUsername(string emailAddress)
        {
            var orders = _ordersDbContext.Orders
                .Where(o => o.EmailAddress == emailAddress);

            return orders.Select(o => new UserOrderDto
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CreatedAt = o.CreatedAt
            });
        }
    }
}