using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Dto;
using System;
namespace SSTTEK.Services.Contacts.Queries.GetContactByUUID
{
    public class GetContactByUUIDQuery : IRequest<ResponseState<ContactDto>>
    {
        public GetContactByUUIDQuery(Guid uuid)
        {
            UUID = uuid;
        }

        public Guid UUID { get; }
    }    
}
