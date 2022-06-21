using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ResponseState>
    {
        private readonly IContactService _contactService;
        public DeleteContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ResponseState> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactService.DeleteAsync(request.UUID);
        }
    }
}
