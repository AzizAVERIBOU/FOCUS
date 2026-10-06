using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("api/error")]
public class ErrorController : ControllerBase
{
    [HttpGet("not-found")]
    public IActionResult DemoNotFound()
    {
        return Problem(
            title: "Resource not found",
            detail: "No resource matches the given id.",
            statusCode: StatusCodes.Status404NotFound);
    }
}
