using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDAL.Repositories
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllAsyncIQueryable(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetEntityAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T?> GetByTIdAsync<A>(A id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
