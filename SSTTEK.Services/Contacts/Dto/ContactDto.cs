using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Dto
{
    public class ContactDto
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }

    }
}
