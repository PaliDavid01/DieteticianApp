using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AllergenMaterialLogic : CRUDLogic<AllergenMaterial>, IAllergenMaterialLogic
    {
        private readonly IAllergenMaterialRepository _repository;
        private readonly IAllergenRepository _allergenRepository;
        public AllergenMaterialLogic(IAllergenMaterialRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id)
        {
            return await _repository.GetAllergensByMaterialId(Id);
        }
        public async Task CreateAllergenMaterials(List<AllergenMaterial> allergenMaterials)
        {
            foreach (var allergenMaterial in allergenMaterials)
            {
                await _repository.CreateAsync(allergenMaterial);
            }
        }
        public async Task UpdateAllergenMaterials(UpdateAllergenMaterialsDTO updateAllergenMaterialsDTO)
        {
            var allergenMaterials = updateAllergenMaterialsDTO.AllergenMaterials;

            var allergenMAgterialsAlreadyHas = await _repository.FindAsync(t => t.MaterialId == updateAllergenMaterialsDTO.MaterialId);

            foreach (var allergenMaterial in allergenMaterials)
            {
                if (!(allergenMAgterialsAlreadyHas.Any(x => x.AllergenId == allergenMaterial.AllergenId)))
                {
                    await _repository.CreateAsync(allergenMaterial);
                }
                else if (allergenMAgterialsAlreadyHas.Any(x => x.AllergenId == allergenMaterial.AllergenId))
                {

                }
            }
            var allergenMaterialsToDelete = allergenMAgterialsAlreadyHas.Where(x => !allergenMaterials.Any(y => y.AllergenId == x.AllergenId));
            foreach (var allergenMaterial in allergenMaterialsToDelete)
            {
                await _repository.DeleteAsync(allergenMaterial);
            }
        }


    }
}
