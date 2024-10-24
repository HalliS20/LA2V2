using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models.InputModels;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAllProducts()
    {
        var products = productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = productService.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost("")]
    public IActionResult CreateProduct([FromBody] ProductInputModel product)
    {
        productService.AddProduct(product);
        return Ok(product);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, [FromBody] ProductInputModel product)
    {
        var updated = productService.UpdateProduct(id, product);
        if (!updated) return NotFound();
        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var deleted = productService.DeleteProduct(id);
        if (!deleted) return NotFound();
        return Ok();
    }
}