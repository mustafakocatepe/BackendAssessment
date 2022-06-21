using SSTTEK.Entities.Concrete;
using SSTTEK.Services.Contacts.Commands;
using SSTTEK.Services.Contacts.Dto;
using AutoMapper;

namespace SSTTEK.Services.Contacts
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
        }    
    }
}
