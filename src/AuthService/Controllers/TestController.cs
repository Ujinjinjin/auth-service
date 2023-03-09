using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[Controller]
public class TestController : Controller
{
    private readonly IConfiguration _configuration;
    
    public TestController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    [HttpGet, Route("api/test")]
    public IActionResult Test()
    {
        return Ok("Hello world: " + _configuration["AllowedHosts"]);
    }
}