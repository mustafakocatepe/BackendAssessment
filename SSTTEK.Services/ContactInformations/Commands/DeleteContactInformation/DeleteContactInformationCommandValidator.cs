using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.ContactInformations.Services.Abstract;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Commands.DeleteContactInformation
{
    public class DeleteContactInformationCommandValidator : IRequestHandler<DeleteContactInformationCommand, ResponseState>
    {
        private readonly IContactInformationService _contactInformationService;
        public DeleteContactInformationCommandValidator(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        public Task<ResponseState> Handle(DeleteContactInformationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
