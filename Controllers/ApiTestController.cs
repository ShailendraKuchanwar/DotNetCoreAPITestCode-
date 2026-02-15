using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Api tested without Authorization...");
        }

        [Authorize]
        [HttpGet]
        public IActionResult TestWithAuthorization()
        {
            return Ok("Api tested without Authorization...");
        }
    }
}
