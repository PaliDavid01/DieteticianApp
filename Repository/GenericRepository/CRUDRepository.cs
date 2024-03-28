//using Castle.Core.Internal;
//using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Models;
using Repository.Interfaces.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public abstract class CRUDRepository<T>  : ICRUDRepository<T> where T : class
    {
        protected readonly DataBaseContext _dbContext;
        public CRUDRepository(DataBaseContext dbContext)
        {
                this._dbContext = dbContext;
        }

        public void Create(T item)
        {
                _dbContext.Set<T>().Add(item);
                _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Set<T>().Remove(Read(id));
            _dbContext.SaveChanges();
        }

        public T Read(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            _dbContext.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        // Create
        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        // Read by ID
        public async Task<T> ReadByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        // Read all
        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        // Update
        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete by entity
        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete by ID
        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Generic method to get entities with conditions
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
