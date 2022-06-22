using Microsoft.EntityFrameworkCore;
using SSTTEK.DataAccess.Context;
using SSTTEK.DataAccess.Repositories.EntityFramework.Read.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Repositories.EntityFramework.Read.Concrete
{
    public abstract class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    {
            
        private readonly SSTTEKReadContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public ReadRepository(SSTTEKReadContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> criteria)
        {
            var response = criteria == null ? _dbSet.ToListAsync() : _dbSet.Where(criteria).ToListAsync();
            return await response;
        }
    }
}
