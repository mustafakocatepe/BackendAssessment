using SSTTEK.DataAccess.Context;
using SSTTEK.DataAccess.Repositories.EntityFramework.Read.Abstract;
using SSTTEK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Read.Concrete
{
    public class ContactInformationReadRepository : ReadRepository<ContactInformation>, IContactInformationReadRepository
    {
        private readonly SSTTEKReadContext _context;
        public ContactInformationReadRepository(SSTTEKReadContext context) : base(context)
        {
            _context = context;
        }
    }
}
