using AutoMapper;
using ECommerce.Infrastructure.Common.Enums;
using SSTTEK.DataAccess.Repositories.Abstract;
using SSTTEK.Entities.Concrete;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Commands;
using SSTTEK.Services.Contacts.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        #region Commands
        public async Task<ResponseState> CreateAsync(CreateContactCommand request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _contactRepository.AddAsync(contact);
            return new ResponseState(StateCode.ProductCreated);
        }
        #endregion

    }
}
