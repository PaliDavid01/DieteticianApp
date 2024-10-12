using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class MealRecipeLogic : CRUDLogic<MealRecipe>, IMealRecipeLogic
    {
        public MealRecipeLogic(IMealRecipeRepository repository) : base(repository)
        {
        }
    }
}
