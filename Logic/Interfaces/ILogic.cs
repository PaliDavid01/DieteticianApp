using Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ILogic<T> where T : class 
    {
        void Create(T item);
        void Update(T item);

        void Delete(int Id);
        T Get(int Id);

        IQueryable<T> GetAll();
    }
}
