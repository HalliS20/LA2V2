using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models.Entities;

namespace ProductCatalog.Repository.Contexts
{
    public class ProductsApiContext(DbContextOptions<ProductsApiContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}