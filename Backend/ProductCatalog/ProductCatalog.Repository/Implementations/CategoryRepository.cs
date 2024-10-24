using ProductCatalog.Models.Dtos;
using ProductCatalog.Models.Entities;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Repository.Contexts;
using ProductCatalog.Repository.Interfaces;

namespace ProductCatalog.Repository.Implementations;

public class CategoryRepository(ProductsApiContext dbContext) : ICategoryRepository
{
    public IEnumerable<CategoryDto> GetAllCategories()
    {
        return dbContext.Categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }

    public void AddCategory(CategoryInputModel category)
    {
        var newCategory = new Category
        {
            Name = category.Name,
            Description = category.Description
        };
        dbContext.Categories.Add(newCategory);
        dbContext.SaveChanges();
    }

    public bool UpdateCategory(CategoryInputModel category)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCategory(int id)
    {
        var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return false;
        dbContext.Categories.Remove(category);
        dbContext.SaveChanges();
        return true;
    }

    public bool UpdateCategory(int id, CategoryInputModel category)
    {
        var categoryToUpdate = dbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (categoryToUpdate == null) return false;
        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
        dbContext.SaveChanges();
        return true;
    }
}