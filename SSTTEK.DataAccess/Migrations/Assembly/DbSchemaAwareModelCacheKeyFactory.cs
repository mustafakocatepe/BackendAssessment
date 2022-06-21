using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SSTTEK.DataAccess.Context;

namespace SSTTEK.DataAccess.Migrations.Assembly
{
    public class DbSchemaAwareModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(Microsoft.EntityFrameworkCore.DbContext context)
        {
            return new
            {
                Type = context.GetType(),
                Schema = context is IAPCContext schema ? schema.Schema : null
            };
        }
    }
}
