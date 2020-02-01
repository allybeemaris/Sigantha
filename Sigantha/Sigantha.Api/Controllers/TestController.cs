using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Sigantha.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok("Hello World");
        }
    }
}
