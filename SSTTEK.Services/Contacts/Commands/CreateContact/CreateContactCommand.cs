using MediatR;
using SSTTEK.Services.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.Services.Contacts.Commands
{
    public class CreateContactCommand  : IRequest<ResponseState>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Firm { get; set; }
    }
}
