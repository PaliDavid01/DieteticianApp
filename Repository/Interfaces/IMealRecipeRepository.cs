using Models.DTOs;
using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IMealRecipeRepository : ICRUDRepository<MealRecipe>
    {
        Task<IEnumerable<GetMealRecipe>> GetAllDTO(int mealId);
    }
}
