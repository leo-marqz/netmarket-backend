using API.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorsController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorResponse(code, "Endpoint not found."));
        }
    }
}
