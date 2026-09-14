using Microsoft.AspNetCore.Mvc;

// namespace sert a préciser l'espace de nommage de la classe
namespace AuthService.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "OK" });
    }
}