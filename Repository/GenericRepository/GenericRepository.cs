using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public abstract class GenericRepository<T>  : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        public GenericRepository(DbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public void Create(T item)
        {
                dbContext.Set<T>().Add(item);
                dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            dbContext.Set<T>().Remove(Read(id));
            dbContext.SaveChanges();
        }

        public abstract T Read(string id);

        public IQueryable<T> ReadAll()
        {
            return dbContext.Set<T>();
        }

        public abstract void Update(T item);
    }
}
