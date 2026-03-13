using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Users =
        [
            "Netcode", "Hub", "Fred"
        ];

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }
    }
}
