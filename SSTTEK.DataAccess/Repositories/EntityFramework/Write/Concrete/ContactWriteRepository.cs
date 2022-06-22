using ECommerce.Infrastructure.Repositories;
using SSTTEK.DataAccess.Context;
using SSTTEK.DataAccess.Repositories.EntityFramework.Abstract;
using SSTTEK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Concrete
{
    public class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
    {
        private readonly SSTTEKWriteContext _context;
        public ContactWriteRepository(SSTTEKWriteContext context) : base(context)
        {
            _context = context;
        }

        public virtual bool Remove(Guid UUID)
        {
            try
            {
                var count = _context.Set<Contact>()
                                    .Where(x => x.UUID == UUID && !x.IsDelete)
                                    .UpdateFromQuery(x => new Contact() { IsDelete = true });

                if (count <= 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
