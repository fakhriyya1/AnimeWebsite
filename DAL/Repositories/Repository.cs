using AnimeDAL.Context;
using AnimeDAL.UnitOfWorks;
using AnimeEntity.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> Table;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            Table = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
                query = query.Where(predicate);

            if (includes.Any())
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public IQueryable<T> GetAllAsyncIQueryable(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public async Task<T?> GetByTIdAsync<A>(A id)
        {
            return await Table.FindAsync(id);
        }

        public Task<T?> GetEntityAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includes.Any())
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
}


// class: Indicates that T must be a reference type (class).
// IEntityBase: This suggests that T should implement the IEntityBase interface.
// new(): Requires T to have a parameterless constructor.
