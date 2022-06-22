using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Commands.CreateContactInformation
{
    public class CreateContactInformationValidator : AbstractValidator<CreateContactInformationCommand>
    {
        public CreateContactInformationValidator()
        {
            RuleFor(x => x.UUID).NotEmpty().WithMessage("Bu alan boş olamaz.");
            RuleFor(x => x.ContactInformation.InformationType).NotEmpty().WithMessage("Bu alan boş olamaz.");           
            RuleFor(x => x.ContactInformation.ContactInformation).NotEmpty().WithMessage("Bu alan boş olamaz.");
        }
    }
}
