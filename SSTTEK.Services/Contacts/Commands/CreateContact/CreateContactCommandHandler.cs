using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ResponseState>
    {
        private readonly IContactService _contactService;
        public CreateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ResponseState> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactService.CreateAsync(request);
        }
    }
}
