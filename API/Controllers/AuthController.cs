using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("Auth controller");
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok("Register endpoint");
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok("Login endpoint");
        }

    }
}
