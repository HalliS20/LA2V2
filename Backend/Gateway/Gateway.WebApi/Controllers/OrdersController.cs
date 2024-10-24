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
public class OrdersController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public OrdersController(HttpClient httpClient, IM2MAuthenticationService authService, ServiceIpOptions serviceIpOptions)
    {
        _httpClient = httpClient;
        var token = authService.RetrieveAccessToken("https://orders-web-api.com").Result;
        _httpClient.BaseAddress = new Uri(serviceIpOptions.Orders + "/api/orders/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllOrders()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "");
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound();

        var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDto>>();

        return Ok(orders);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateNewOrder([FromBody] OrderInputModel order)
    {
        var content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync("", content).Result;
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return BadRequest("One or more products with ID in items does not exist");

        var newOrder = await response.Content.ReadFromJsonAsync<OrderInputModel>();

        return Ok(newOrder);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var response = await _httpClient.GetAsync($"{id}");
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound($"Order with id {id} was not found");

        var order = await response.Content.ReadFromJsonAsync<OrderDetailsDto>();

        return Ok(order);
    }

    [HttpGet("users/{username}")]
    public async Task<IActionResult> GetOrderByUsername(string username)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"users/{username}");
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.NoContent) return NoContent();
        if (response.StatusCode == HttpStatusCode.Unauthorized) return Unauthorized();
        if (!response.IsSuccessStatusCode) return NotFound();

        var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDto>>();

        return Ok(orders);
    }
}
