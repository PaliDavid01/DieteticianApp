using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AllergenMaterialLogic : CRUDLogic<AllergenMaterial>, IAllergenMaterialLogic
    {
        private readonly IAllergenMaterialRepository _repository;
        public AllergenMaterialLogic(IAllergenMaterialRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id)
        {
            return await _repository.GetAllergensByMaterialId(Id);
        }
    }
}
