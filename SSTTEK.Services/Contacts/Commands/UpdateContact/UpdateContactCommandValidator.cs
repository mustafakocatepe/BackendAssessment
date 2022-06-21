using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.UUID).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.Contact.Name).NotEmpty().WithMessage("Bu alan boş olamaz.");
            RuleFor(x => x.Contact.LastName).NotEmpty().WithMessage("Bu alan boş olamaz.");
            RuleFor(x => x.Contact.Firm).NotEmpty().WithMessage("Bu alan boş olamaz.");
        }
    }
}
