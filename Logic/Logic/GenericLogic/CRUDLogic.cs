using Logic.Interfaces.GenericInterfaces;
using Repository.Interfaces.GenericInterfaces;
using System.Linq.Expressions;

namespace Logic.Logic.GenericLogic
{
    public class CRUDLogic<T> : ICRUDLogic<T> where T : class
    {
        ICRUDRepository<T> _repository;
        public CRUDLogic(ICRUDRepository<T> repository) 
        {
            _repository = repository;
        }
        public void Create(T entity)
        {
            _repository.Create(entity);
        }

        public Task<T> CreateAsync(T entity)
        {
            return _repository.CreateAsync(entity);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public Task DeleteAsync(T entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task DeleteByIdAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindAsync(predicate);
        }

        public T Read(int Id)
        {
            return _repository.Read(Id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _repository.ReadAll();
        }

        public Task<IEnumerable<T>> ReadAllAsync()
        {
            return _repository.ReadAllAsync();
        }

        public Task<T> ReadByIdAsync(int id)
        {
            return _repository.ReadByIdAsync(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public Task UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
