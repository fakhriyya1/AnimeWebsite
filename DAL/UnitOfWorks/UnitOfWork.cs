using AnimeDAL.Context;
using AnimeDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValueTask DisposeAsync()
        {
           return dbContext.DisposeAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
           return dbContext.SaveChangesAsync();   
        }
    }
}
