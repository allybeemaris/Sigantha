﻿using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Sigantha.Content.Commands;
using Sigantha.Content.Queries;

namespace Sigantha.Api.Controllers
{
    [Route("api")]
    public class TimelinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimelinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Timelines")]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new TimelineGetAll.Query()));

        [HttpGet]
        [Route("Timelines/{Id}")]
        public async Task<IActionResult> Get(TimelineGet.Query query)
            => Ok(await _mediator.Send(query));

        [HttpPost]
        [Route("Timelines")]
        public async Task<IActionResult> Create([FromBody] TimelineCreate.Command command)
            => Created("", await _mediator.Send(command));

        [HttpPut]
        [Route("Timelines")]
        public async Task<IActionResult> Update([FromBody] TimelineUpdate.Command command)
            => Ok(await _mediator.Send(command));

        [HttpDelete]
        [Route("Timelines/{Id}")]
        public async Task<IActionResult> Delete(TimelineDelete.Command command)
            => Ok(await _mediator.Send(command));
    }
}
