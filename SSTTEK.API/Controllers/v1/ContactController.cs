using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Commands;
using SSTTEK.Services.Contacts.Commands.DeleteContact;
using SSTTEK.Services.Contacts.Commands.UpdateContact;
using SSTTEK.Services.Contacts.Dto;
using SSTTEK.Services.Contacts.Queries.GetContactByUUID;
using SSTTEK.Services.Contacts.Queries.GetContacts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSSTTEK.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/contacts")]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseState), 201)]
        [ProducesResponseType(typeof(ResponseState), 400)]
        [ProducesResponseType(500)]
        public async Task<ResponseState> AddAsync([FromBody] CreateContactCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseState), 204)]
        [ProducesResponseType(typeof(ResponseState), 404)]
        [ProducesResponseType(500)]
        public async Task<ResponseState> DeleteAsync(Guid UUID)
        {
            return await _mediator.Send(new DeleteContactCommand(UUID));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseState), 204)]
        [ProducesResponseType(typeof(ResponseState), 404)]
        [ProducesResponseType(500)]
        public async Task<ResponseState> UpdateAsync(Guid UUID, [FromBody] UpdateContactDto command)
        {
            return await _mediator.Send(new UpdateContactCommand(UUID, command));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseState<List<ContactDto>>), 200)]
        [ProducesResponseType(typeof(ResponseState), 404)]
        [ProducesResponseType(500)]
        public async Task<ResponseState<List<ContactDto>>> GetAllAsync()
        {
            return await _mediator.Send(new GetContactsQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseState<ContactDto>), 200)]
        [ProducesResponseType(typeof(ResponseState), 404)]
        [ProducesResponseType(500)]
        public async Task<ResponseState<ContactDto>> GetAsync([FromRoute] Guid uuid)
        {
            return await _mediator.Send(new GetContactByUUIDQuery(uuid));
        }


    }
}