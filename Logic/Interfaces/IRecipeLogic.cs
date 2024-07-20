using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IRecipeLogic : ICRUDLogic<Recipe>
    {
        Task RecalculateMacros(int recipeId);
    }
}