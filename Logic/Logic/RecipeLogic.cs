using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class RecipeLogic : CRUDLogic<Recipe>, IRecipeLogic
    {
        public RecipeLogic(IRecipeRepository repository) : base(repository)
        {
        }
    }
}
