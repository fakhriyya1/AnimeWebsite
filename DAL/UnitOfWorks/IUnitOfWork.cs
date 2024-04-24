using AnimeDAL.Repositories;
using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDAL.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T:class, IEntityBase, new();

        Task<int> SaveChangesAsync();
    }
}


//Asynchronous Save Method (SaveAsync()):

//The asynchronous Save method performs the save operation asynchronously. This allows the calling code to continue executing while the save operation is in progress, potentially improving the responsiveness and scalability of the application.
//Asynchronous methods are often preferred in scenarios where the calling code needs to perform other asynchronous operations concurrently or when the operation involves waiting for I/O-bound tasks, such as database operations.
//Regarding the return type of Save, it's common to see Save methods returning an integer value representing the number of affected rows or entities after the save operation. This integer value typically indicates how many entities were inserted, updated, or deleted as a result of the save operation.