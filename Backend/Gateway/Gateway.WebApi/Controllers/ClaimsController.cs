using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;


namespace Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{

    [HttpGet("profile")]
    public IActionResult Profile()
    {
        return Ok(new
        {
            User.Identity?.Name,
            EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
        });
    }
}