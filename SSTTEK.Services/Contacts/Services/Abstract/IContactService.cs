using SSTTEK.Entities.Concrete;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Commands;
using SSTTEK.Services.Contacts.Commands.UpdateContact;
using SSTTEK.Services.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Services.Abstract
{
    public interface IContactService
    {
        Task<Contact> DetailAsync(Guid UUID);
        Task<ResponseState> CreateAsync(CreateContactCommand request);
        Task<ResponseState<List<ContactDto>>> GetAllAsync();
        Task<ResponseState<ContactDto>> GetByIdAsync(Guid UUID);
        Task<ResponseState> UpdateAsync(UpdateContactCommand request);
        Task<ResponseState> DeleteAsync(Guid UUID);
    }
}
