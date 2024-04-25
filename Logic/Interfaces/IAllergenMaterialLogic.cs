using Logic.Interfaces.GenericInterfaces;
using Models.DTOs;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IAllergenMaterialLogic : ICRUDLogic<AllergenMaterial>
    {
        Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id);
        Task CreateAllergenMaterials(List<AllergenMaterial> allergenMaterials);
        Task UpdateAllergenMaterials(UpdateAllergenMaterialsDTO updateAllergenMaterialsDTO);
    }
}
