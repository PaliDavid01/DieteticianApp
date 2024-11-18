using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class MealRecipeLogic : CRUDLogic<MealRecipe>, IMealRecipeLogic
    {
        private readonly IMealRecipeRepository _repository;
        public MealRecipeLogic(IMealRecipeRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetMealRecipe>> GetAllDTO(int mealId)
        {
            return await _repository.GetAllDTO(mealId);
        }
    }
}
