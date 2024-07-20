using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IIngredientLogic : ICRUDLogic<Ingredient>
    {
        Task<IEnumerable<IngredientDataView>> GetAllByRecipeId(int recipeId);
    }
}