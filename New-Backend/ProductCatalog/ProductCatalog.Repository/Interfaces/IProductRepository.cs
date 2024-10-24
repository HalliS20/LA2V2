using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Repository.Interfaces;

public interface IProductRepository
{
    IEnumerable<ProductDto> GetAllProducts();
    ProductDto? GetProductById(int id);
    void AddProduct(ProductInputModel product);
    bool UpdateProduct(int id, ProductInputModel product);
    bool DeleteProduct(int id);
}