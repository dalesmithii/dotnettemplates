using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceName.Api.Application.Commands;

namespace ServiceName.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class SampleController : Controller
    {
        private readonly IMediator _mediator;

        public SampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("Hello")]
        [HttpPost]
        public async Task<IActionResult> Hello([FromBody]SampleCommand sampleCommand)
        {
            var result = await _mediator.Send(sampleCommand);
            return Ok(result);
        }
    }
}
