using Models.DTOs;
using Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMaterialLogic 
    {
        void Create(Material item);
        void Update(Material item);

        void Delete(string Id);
        Material Get(string Id);

        IQueryable<Material> GetAll();       
    }
}
