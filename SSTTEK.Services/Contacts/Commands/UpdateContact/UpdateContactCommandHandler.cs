using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResponseState>
    {
        private readonly IContactService _contactService;
        public UpdateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public Task<ResponseState> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            return _contactService.UpdateAsync(request);
        }
    }
}
