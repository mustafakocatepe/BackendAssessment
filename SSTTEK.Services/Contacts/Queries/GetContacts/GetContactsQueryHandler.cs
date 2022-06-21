using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Dto;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, ResponseState<List<ContactDto>>>
    {
        private readonly IContactService _contactService;
        public GetContactsQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ResponseState<List<ContactDto>>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _contactService.GetAllAsync();
        }
    }
}
