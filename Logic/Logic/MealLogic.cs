using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class MealLogic : CRUDLogic<Meal>, IMealLogic
    {
        private readonly IMealRepository _repository;
        public MealLogic(IMealRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int CreateWithReturnId(Meal meal)
        {
            return _repository.CreateWithReturnId(meal);
        }

        public async Task<GetMealMacroDataResult> GetMealMacroData(int mealId)
        {
            return await _repository.GetMealMacroData(mealId);
        }
    }
}
