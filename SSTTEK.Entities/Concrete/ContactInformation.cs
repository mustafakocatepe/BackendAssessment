using SSTTEK.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Entities.Concrete
{
    public class ContactInformation
    {
        public Guid UUID { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid ContactUUID { get; set; }
        public Contact Contact { get; set; }
    }
}
