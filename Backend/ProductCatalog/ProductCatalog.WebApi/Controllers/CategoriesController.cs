using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAllCategories()
    {
        var categories = categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpPost("")]
    public IActionResult CreateCategory([FromBody] CategoryInputModel category)
    {
        categoryService.AddCategory(category);
        return Ok(category);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCategory(int id, [FromBody] CategoryInputModel categoryItem)
    {
        var success = categoryService.UpdateCategory(id, categoryItem);
        if (!success) return NotFound();
        return Ok(categoryItem);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategory(int id)
    {
        var success = categoryService.DeleteCategory(id);
        if (!success) return NotFound();
        return Ok();
    }
}