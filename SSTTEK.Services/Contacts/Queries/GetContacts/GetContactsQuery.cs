using MediatR;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<ResponseState<List<ContactDto>>>
    {
    }
}
