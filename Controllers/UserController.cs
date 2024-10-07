using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archi.AppUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
