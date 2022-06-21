using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.ContactInformations.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Commands.CreateContactInformation
{
    public class CreateContactInformationCommand : IRequest<ResponseState>
    {
        public CreateContactInformationCommand(Guid uuid, CreateContactInformationDto contactInformation)
        {
            UUID = uuid;
            ContactInformation = contactInformation;

        }
        public Guid UUID { get; set; }
        public CreateContactInformationDto ContactInformation { get; set; }

    }
}
