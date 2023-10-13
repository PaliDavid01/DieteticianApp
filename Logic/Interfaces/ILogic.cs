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

        void Delete(string Id);
        T Get(string Id);

        IQueryable<T> GetAll();
    }
}
