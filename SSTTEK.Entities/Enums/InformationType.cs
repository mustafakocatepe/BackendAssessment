using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Entities.Enums
{
    public enum InformationType
    {
        [Display(Name = "Phone Number")]
        PhoneNumber = 1,
        [Display(Name = "Email Address")]
        EmailAddress = 2,
        [Display(Name = "Location")]
        Location = 3
    }
}
