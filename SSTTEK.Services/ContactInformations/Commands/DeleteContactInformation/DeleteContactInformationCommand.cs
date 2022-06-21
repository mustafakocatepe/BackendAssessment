using MediatR;
using SSTTEK.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Commands.DeleteContactInformation
{
    public class DeleteContactInformationCommand : IRequest<ResponseState>
    {
        public DeleteContactInformationCommand(Guid uuid)
        {
            UUID = uuid;
        }
        public Guid UUID { get; set; }
    }
}
