using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.ContactInformations.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Commands.CreateContactInformation
{
    public class CreateContactInformationHandler : IRequestHandler<CreateContactInformationCommand, ResponseState>
    {
        private readonly IContactInformationService _contactInformationService;
        public CreateContactInformationHandler(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }
        public Task<ResponseState> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
