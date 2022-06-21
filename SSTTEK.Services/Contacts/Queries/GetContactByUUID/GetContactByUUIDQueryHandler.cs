using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Dto;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Queries.GetContactByUUID
{
    public class GetContactByUUIDQueryHandler : IRequestHandler<GetContactByUUIDQuery, ResponseState<ContactDto>>
    {
        private readonly IContactService _contactService;
        public GetContactByUUIDQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ResponseState<ContactDto>> Handle(GetContactByUUIDQuery request, CancellationToken cancellationToken)
        {
            return await _contactService.GetByIdAsync(request.UUID);
        }
    }
}
