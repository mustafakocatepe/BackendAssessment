using AutoMapper;
using ECommerce.Infrastructure.Common.Enums;
using ECommerce.Infrastructure.Common.Exceptions;
using SSTTEK.DataAccess.Repositories.EntityFramework.Abstract;
using SSTTEK.DataAccess.Repositories.EntityFramework.Read.Abstract;
using SSTTEK.Entities.Concrete;
using SSTTEK.Services.Common.Models;
using SSTTEK.Services.ContactInformations.Commands.CreateContactInformation;
using SSTTEK.Services.ContactInformations.Services.Abstract;
using SSTTEK.Services.Contacts.Services.Abstract;
using SSTTEK.Services.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Services.Concrete
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IContactInformationWriteRepository _contactInformationWriteRepository;
        private readonly IContactInformationReadRepository _contactInformationReadRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactInformationService(IContactInformationWriteRepository contactInformationWriteRepository, IContactInformationReadRepository contactInformationReadRepository, IContactService contactService, IRedisCacheService redisCacheService, IMapper mapper)
        {
            _contactInformationWriteRepository = contactInformationWriteRepository;
            _contactInformationReadRepository = contactInformationReadRepository;
            _redisCacheService = redisCacheService;
            _contactService = contactService;
            _mapper = mapper;
        }

        #region Common
        public async Task<ContactInformation> DetailAsync(Guid UUID)
        {
            var contactInformation = await _contactInformationReadRepository.FirstOrDefaultAsync(x => x.UUID == UUID && !x.IsDelete);

            if (contactInformation == null)            
                throw new StateException { StateCode = StateCode.ContactNotFound };            

            return contactInformation;
        }
        #endregion

        #region Commands
        public async Task<ResponseState> CreateAsync(CreateContactInformationCommand request)
        {
            var contact = _contactService.DetailAsync(request.UUID);

            if (contact == null)            
                return new ResponseState(StateCode.ContactNotFound); //TODO: Contact Not Found

            //TODO : Contact id ataması
            //TODO _mapper.Map
            await _contactInformationWriteRepository.AddAsync(new Entities.Concrete.ContactInformation
            {
                UUID = new Guid(),
                InformationType = request.ContactInformation.InformationType,
                InformationContent = request.ContactInformation.ContactInformation,
                CreatedDate = DateTime.Now,
                IsDelete = false
            });

            return new ResponseState(StateCode.ContactInformationCreated);
        }

        public async Task<ResponseState> DeleteAsync(Guid UUID)
        {
            await DetailAsync(UUID);
            _contactInformationWriteRepository.Remove(UUID);
            return new ResponseState(StateCode.ContactInformationDeleted);
        }
        #endregion

        #region Queries
        #endregion


    }
}
