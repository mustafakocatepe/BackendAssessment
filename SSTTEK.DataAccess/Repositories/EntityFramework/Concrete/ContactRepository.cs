using SSTTEK.DataAccess.Repositories.EntityFramework.Abstract;
using SSTTEK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Concrete
{
    public class ContactRepository : EfRepository<Contact>, IContactRepository
    {

    }
}
