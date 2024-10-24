using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProducts();
    ProductDto? GetProductById(int id);
    void AddProduct(ProductInputModel product);
    bool UpdateProduct(int id, ProductInputModel product);
    bool DeleteProduct(int id);
}