using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AuthController : BaseApiController
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
