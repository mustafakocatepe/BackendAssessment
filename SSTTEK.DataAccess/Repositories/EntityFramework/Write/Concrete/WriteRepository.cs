using ECommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SSTTEK.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public abstract class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
    {
        private readonly SSTTEKWriteContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public WriteRepository(SSTTEKWriteContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
