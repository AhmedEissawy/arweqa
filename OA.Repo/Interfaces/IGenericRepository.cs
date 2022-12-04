using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entites);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entites);
        Task<TEntity> ReloadAsync(TEntity entity);
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterPredicate);
      
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filterPredicate, Expression<Func<TEntity, dynamic>> selector);
        Task<int> SaveChangesAsync();
    }
}

