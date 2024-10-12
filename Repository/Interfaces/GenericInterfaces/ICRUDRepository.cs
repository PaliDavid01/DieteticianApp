using System.Linq.Expressions;

namespace Repository.Interfaces.GenericInterfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        T Create(T entity);
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
