using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<ResponseState>
    {
        public UpdateContactCommand(Guid uuid, UpdateContactDto contact)
        {
            UUID = uuid;
            Contact = contact;

        }
        public Guid UUID { get; set; }
        public UpdateContactDto Contact { get; set; }
    }
}
