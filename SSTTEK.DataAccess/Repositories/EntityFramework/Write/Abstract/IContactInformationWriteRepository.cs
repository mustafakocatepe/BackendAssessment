using ECommerce.Domain.Repositories;
using SSTTEK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Abstract
{
    public interface IContactInformationWriteRepository : IWriteRepository<ContactInformation>
    {
        bool Remove(Guid UUID);

    }
}
