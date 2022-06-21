using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Bu alan boş olamaz."); 
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Bu alan boş olamaz.");
            RuleFor(c => c.Firm).NotEmpty().WithMessage("Bu alan boş olamaz.");
        }
    }
    
}
