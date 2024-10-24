using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Entities;
using ProductCatalog.Models.Entities;

namespace Orders.API.Contexts
{
    public class OrdersApiContext : DbContext
    {
        public OrdersApiContext(DbContextOptions<OrdersApiContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}