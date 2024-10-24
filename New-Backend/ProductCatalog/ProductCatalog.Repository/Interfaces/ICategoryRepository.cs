using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;

namespace ProductCatalog.Repository.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<CategoryDto> GetAllCategories();
    void AddCategory(CategoryInputModel category);
    bool UpdateCategory(int id, CategoryInputModel category);
    bool DeleteCategory(int id);
}