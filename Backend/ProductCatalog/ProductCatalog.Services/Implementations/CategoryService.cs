using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repository.Interfaces;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Services.Implementations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public IEnumerable<CategoryDto> GetAllCategories()
    {
        return categoryRepository.GetAllCategories();
    }

    public void AddCategory(CategoryInputModel category)
    {
        categoryRepository.AddCategory(category);
    }

    public bool DeleteCategory(int id)
    {
        return categoryRepository.DeleteCategory(id);
    }

    public bool UpdateCategory(int id, CategoryInputModel category)
    {
        return categoryRepository.UpdateCategory(id, category);
    }
}