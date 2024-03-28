using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AllergenLogic : CRUDLogic<Allergen>, IAllergenLogic
    {
        public AllergenLogic(IAllergenRepository repository) : base(repository)
        {
        }
    }
}
