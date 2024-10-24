using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models.InputModels;
using OrderManagement.Services.Interfaces;

namespace OrderManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("{id:int}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("users/{username}")]
        public IActionResult GetOrdersByUsername(string username)
        {
            return Ok(_orderService.GetOrdersByUsername(username));
        }

        [HttpPost("")]
        public IActionResult CreateNewOrder([FromBody] OrderInputModel orderInputModel)
        {
            var success = _orderService.CreateNewOrder(orderInputModel);
            Console.WriteLine("Creating new order in repository");

            if (!success)
            {
                return BadRequest();
            }

            return Ok(orderInputModel);
        }
    }
}
