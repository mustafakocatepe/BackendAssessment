using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSTTEK.Services.Common.Models;
using System;
using System.Threading.Tasks;

namespace SSTTEK.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/contact-informations")]
    public class ContactInformationController : Controller
    {
        private readonly IMediator _mediator;
        public ContactInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseState), 201)]
        [ProducesResponseType(typeof(ResponseState), 400)]
        [ProducesResponseType(500)]
        public async Task<ResponseState> AddAsync(Guid UUID, [FromBody] CreateContactCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
