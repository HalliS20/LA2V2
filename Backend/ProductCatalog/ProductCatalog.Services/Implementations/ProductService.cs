using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repository.Interfaces;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Services.Implementations;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public IEnumerable<ProductDto> GetAllProducts()
    {
        return productRepository.GetAllProducts();
    }

    public ProductDto? GetProductById(int id)
    {
        return productRepository.GetProductById(id);
    }

    public void AddProduct(ProductInputModel product)
    {
        productRepository.AddProduct(product);
    }

    public bool DeleteProduct(int id)
    {
        return productRepository.DeleteProduct(id);
    }

    public bool UpdateProduct(int id, ProductInputModel product)
    {
        return productRepository.UpdateProduct(id, product);
    }
}