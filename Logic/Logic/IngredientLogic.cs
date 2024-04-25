using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class IngredientLogic : CRUDLogic<Ingredient>, IIngredientLogic
    {
        public IngredientLogic(IIngredientRepository repository) : base(repository)
        {
        }
    }
}
