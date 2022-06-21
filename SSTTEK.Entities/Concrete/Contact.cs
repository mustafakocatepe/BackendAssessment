using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Entities.Concrete
{
    public class Contact
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid ContactInformationUUUID { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
