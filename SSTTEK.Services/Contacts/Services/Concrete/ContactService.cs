using AutoMapper;
using ECommerce.Infrastructure.Common.Enums;
using ECommerce.Infrastructure.Common.Exceptions;
using SSTTEK.DataAccess.Repositories.EntityFramework.Abstract;
using SSTTEK.Entities.Concrete;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.Contacts.Commands;
using SSTTEK.Services.Contacts.Commands.UpdateContact;
using SSTTEK.Services.Contacts.Dto;
using SSTTEK.Services.Contacts.Services.Abstract;
using SSTTEK.Services.Services.Abstract;
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
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;
        private const string ContactDetail = "Contact:{0}";

        public ContactService(IContactRepository contactRepository, IRedisCacheService redisCacheService, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _redisCacheService= redisCacheService;
        }

        #region Common
        public async Task<Contact> DetailAsync(Guid UUID)
        {
            var product = await _contactRepository.FirstOrDefaultAsync(x => x.UUID == UUID && x.IsActive);

            if (product == null)
            {
                throw new StateException { StateCode = StateCode.ContactNotFound };
            }
            else if (!product.IsActive)
            {
                throw new StateException { StateCode = StateCode.ContactNotFound };
            }

            return product;
        }
        #endregion

        #region Commands
        public async Task<ResponseState> CreateAsync(CreateContactCommand request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _contactRepository.AddAsync(contact);
            return new ResponseState(StateCode.ContactCreated);
        }

        public async Task<ResponseState> DeleteAsync(Guid UUID)
        {
            var product = await DetailAsync(UUID);
            _contactRepository.Remove(product.UUID);
            return new ResponseState(StateCode.ContactDeleted);

        }

        public async Task<ResponseState> UpdateAsync(UpdateContactCommand request)
        {
            var contact = await DetailAsync(request.UUID);

            if (!string.IsNullOrWhiteSpace(request.Contact.Name))
                contact.Name = request.Contact.Name;
            if (!string.IsNullOrWhiteSpace(request.Contact.LastName))
                contact.LastName = request.Contact.LastName;
            if (!string.IsNullOrWhiteSpace(request.Contact.Firm))
                contact.Firm = request.Contact.Firm;


            await _contactRepository.Update(contact);
            return new ResponseState(StateCode.ContactUpdated);
        }
        #endregion




        #region Queries
        public async Task<ResponseState<ContactDto>> GetByIdAsync(Guid UUID)
        {
            var cacheKey = string.Format(ContactDetail, UUID);
            var result = _redisCacheService.Get<ContactDto>(cacheKey);

            if (result != null)            
                return new ResponseState<ContactDto>() { Content = result };
            
            var contact = await DetailAsync(UUID);
            return new ResponseState<ContactDto>() { Content = _mapper.Map<ContactDto>(contact) };
        }

        public async Task<ResponseState<List<ContactDto>>> GetAllAsync()
        {
            var contactList = await _contactRepository.WhereAsync(x => x.IsActive);

            var response = _mapper.Map<List<Contact>, List<ContactDto>>(contactList.ToList());

            return new ResponseState<List<ContactDto>>() { Content = response };
        }
        #endregion

    }
}
