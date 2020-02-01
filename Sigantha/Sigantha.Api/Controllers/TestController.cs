using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Sigantha.Timeline.Queries;

namespace Sigantha.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(_mediator.Send(new TestQuery.Query()));
        }
    }
}
