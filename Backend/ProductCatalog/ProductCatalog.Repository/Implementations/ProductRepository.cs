using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.Entities;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repository.Contexts;
using ProductCatalog.Repository.Interfaces;

namespace ProductCatalog.Repository.Implementations;

public class ProductRepository(ProductsApiContext dbContext) : IProductRepository
{
    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = dbContext.Products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId
        });
        return products;
    }

    public ProductDto? GetProductById(int id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return null;
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
        return productDto;
    }

    public void AddProduct(ProductInputModel productInputModel)
    {
        var category = dbContext.Categories.FirstOrDefault(c => c.Id == productInputModel.CategoryId);
        if (category == null) return;
        var newProduct = new Product
        {
            Name = productInputModel.Name,
            Description = productInputModel.Description,
            Price = productInputModel.Price,
            CategoryId = productInputModel.CategoryId
        };
        dbContext.Products.Add(newProduct);
        dbContext.SaveChanges();
    }

    public bool DeleteProduct(int id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;
        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
        return true;
    }

    public bool UpdateProduct(int id, ProductInputModel product)
    {
        var category = dbContext.Categories.FirstOrDefault(c => c.Id == product.CategoryId);
        if (category == null) return false;
        var productToUpdate = dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (productToUpdate == null) return false;
        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.CategoryId = product.CategoryId;
        dbContext.SaveChanges();
        return true;
    }
}