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
    public class ContactReadRepository : ReadRepository<Contact>, IContactReadRepository
    {
        private readonly SSTTEKReadContext _context;
        public ContactReadRepository(SSTTEKReadContext context) : base(context)
        {
            _context = context;
        }
    }
}
