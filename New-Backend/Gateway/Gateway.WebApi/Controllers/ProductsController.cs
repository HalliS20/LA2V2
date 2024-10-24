using System.Net;
using System.Text;
using System.Text.Json;
using Gateway.Models;
using Gateway.Models.Dtos;
using Gateway.Models.InputModels;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ProductsController(HttpClient httpClient, IM2MAuthenticationService authService, ServiceIpOptions serviceIpOptions)
    {
        _httpClient = httpClient;
        var token = authService.RetrieveAccessToken("https://products-web-api.com").Result;
        _httpClient.BaseAddress = new Uri(serviceIpOptions.Products + "/api/products/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }


    [HttpGet("")]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("");
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound();

        var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var response = await _httpClient.GetAsync($"{id}");
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound($"Product with id {id} was not found");
        var product = await response.Content.ReadFromJsonAsync<ProductDto>();

        return Ok(product);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductInputModel product)
    {
        var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync("", content).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest("One or more products with ID in items was not found");
        var newProduct = await response.Content.ReadFromJsonAsync<ProductInputModel>();

        return Ok(newProduct);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductInputModel product)
    {
        var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
        var response = _httpClient.PutAsync($"{id}", content).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest();

        var updatedProduct = await response.Content.ReadFromJsonAsync<ProductInputModel>();

        return Ok(updatedProduct);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var response = _httpClient.DeleteAsync($"{id}").Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest();
        return Ok();
    }
}
