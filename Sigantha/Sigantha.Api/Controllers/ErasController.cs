using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Sigantha.Content.Commands;
using Sigantha.Content.Queries;

namespace Sigantha.Api.Controllers
{
    [Route("api")]
    public class ErasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ErasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Eras")]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new EraGetAll.Query()));

        [HttpGet]
        [Route("Eras/{Id}")]
        public async Task<IActionResult> Get(EraGet.Query query)
            => Ok(await _mediator.Send(query));

        [HttpPost]
        [Route("Eras")]
        public async Task<IActionResult> Create([FromBody] EraCreate.Command command)
            => Created("", await _mediator.Send(command));

        [HttpPut]
        [Route("Eras")]
        public async Task<IActionResult> Update([FromBody] EraUpdate.Command command)
            => Ok(await _mediator.Send(command));

        [HttpDelete]
        [Route("Eras/{Id}")]
        public async Task<IActionResult> Delete(EraDelete.Command command)
            => Ok(await _mediator.Send(command));
    }
}
