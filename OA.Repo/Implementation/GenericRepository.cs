using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        private readonly ProjectContext _dbcontext;
        public GenericRepository(ProjectContext context)
        {
            _dbcontext = context;
            _dbSet = _dbcontext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entites)
        {
            await _dbSet.AddRangeAsync(entites);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterPredicate)
        {
            return await _dbSet.Where(filterPredicate).ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterPredicate, Expression<Func<TEntity, dynamic>> selector)
        {
            return await _dbSet.Where(filterPredicate).Include(selector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(q => !q.Deleted).ToListAsync();
        }

        public async Task<TEntity> ReloadAsync(TEntity entity)
        {
            await _dbcontext.Entry(entity).ReloadAsync();
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entites)
        {
            _dbSet.RemoveRange(entites);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

      
    }
}
