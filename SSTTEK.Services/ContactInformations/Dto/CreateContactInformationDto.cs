using SSTTEK.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.ContactInformations.Dto
{
    public class CreateContactInformationDto
    {
        public InformationType InformationType { get; set; }
        public string ContactInformation { get; set; }
    }
}
