using Logic.Interfaces;
using Models.DTOs;
using Models.Storage;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class MaterialLogic : IMaterialLogic
    {
        private IRepository<Material> _repository;
        public MaterialLogic(IRepository<Material> repository)
        {
            this._repository = repository;
        }
        public void Create(Material material)
        {
            _repository.Create(material);
        }

        public void Delete(string materialId)
        {
            _repository.Delete(materialId);
        }

        public IQueryable<Material> GetAll()
        {
            return _repository.ReadAll();
        }

        public Material Get(string materialId)
        {
            return _repository.Read(materialId);
        }

        public void Update(Material dealership)
        {
            _repository.Update(dealership);
        }
    }
}
