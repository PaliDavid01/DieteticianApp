using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.GenericInterfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(int Id);
        T Read(int Id);
        IEnumerable<T> ReadAll();
        void Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task<T> ReadByIdAsync(int id);
        Task<IEnumerable<T>> ReadAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    }
}
