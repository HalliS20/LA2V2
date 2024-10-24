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

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public CategoriesController(HttpClient httpClient, IM2MAuthenticationService authService, ServiceIpOptions serviceIpOptions)
    {
        _httpClient = httpClient;
        var token = authService.RetrieveAccessToken("https://products-web-api.com").Result;
        _httpClient.BaseAddress = new Uri(serviceIpOptions.Products + "/api/categories/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    [HttpGet("")]
    public IActionResult GetAllCategories()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "");
        var response = _httpClient.SendAsync(request).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound();

        var categories = response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>().Result;
        return Ok(categories);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryInputModel category)
    {
        var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync("", content).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest();

        var newCategory = await response.Content.ReadFromJsonAsync<CategoryInputModel>();

        return Ok(newCategory);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryInputModel categoryItem)
    {
        var content = new StringContent(JsonSerializer.Serialize(categoryItem), Encoding.UTF8, "application/json");
        var response = _httpClient.PutAsync($"{id}", content).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest();

        var updatedCategory = await response.Content.ReadFromJsonAsync<CategoryInputModel>();

        return Ok(updatedCategory);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategory(int id)
    {
        var response = _httpClient.DeleteAsync($"{id}").Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest();

        return Ok();
    }
}