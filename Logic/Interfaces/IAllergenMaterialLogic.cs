using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IAllergenMaterialLogic : ICRUDLogic<AllergenMaterial>
    {
        Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id);
    }
}
