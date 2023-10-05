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
        void Create(Material dealership);
        void Update(Material dealership);

        void DeleteMaterial(string materialId);
        Material GetMaterial(string materialId);

        IQueryable<Material> GetAllMaterials();        
    }
}
