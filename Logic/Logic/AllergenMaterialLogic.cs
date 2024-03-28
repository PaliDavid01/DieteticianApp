using Logic.Interfaces;
using Logic.Interfaces.GenericInterfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AllergenMaterialLogic : CRUDLogic<AllergenMaterial>, IAllergenMaterialLogic
    {
        public AllergenMaterialLogic(IAllergenMaterialRepository repository) : base(repository)
        {
        }
    }
}
