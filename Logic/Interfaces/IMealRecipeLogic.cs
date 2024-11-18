using Logic.Interfaces.GenericInterfaces;
using Models.DTOs;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IMealRecipeLogic : ICRUDLogic<MealRecipe>
    {
        Task<IEnumerable<GetMealRecipe>> GetAllDTO(int mealId);
    }
}
