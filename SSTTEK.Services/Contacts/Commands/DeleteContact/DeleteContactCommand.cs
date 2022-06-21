using MediatR;
using SSTTEK.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<ResponseState>
    {
        public DeleteContactCommand(Guid uuid)
        {
            UUID = uuid;
        }
        public Guid UUID { get; set; }
    }
}
