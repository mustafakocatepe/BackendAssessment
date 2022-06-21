using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria);
        TEntity Find(Expression<Func<TEntity, bool>> criteria);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria = null);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria, int startIndex, int pageSize, string orderBy, string sortDirection);
        TEntity Add(TEntity entity);
        List<TEntity> AddRange(List<TEntity> entities);
        TEntity Edit(TEntity entity);
        bool EditReturnBool(TEntity entity);
        void Delete(TEntity entity);
        bool DeleteReturnBool(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> criteria);
        void DeleteRange(List<TEntity> entities);
        void DeleteRange(Expression<Func<TEntity, bool>> criteria);
        bool DeleteRangeReturn(List<TEntity> entities);
        bool DeleteRangeReturn(Expression<Func<TEntity, bool>> criteria);
        TEntity Single(Expression<Func<TEntity, bool>> criteria);
        TEntity First(Expression<Func<TEntity, bool>> criteria);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> criteria);
        TEntity LastOrDefault(Expression<Func<TEntity, bool>> criteria);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> criteria);
        bool Any(Expression<Func<TEntity, bool>> criteria);
        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);

        Task AddAsync(TEntity entity);



    }
}
