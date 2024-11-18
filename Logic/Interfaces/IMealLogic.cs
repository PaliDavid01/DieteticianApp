using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IMealLogic : ICRUDLogic<Meal>
    {
        int CreateWithReturnId(Meal meal);
        Task<GetMealMacroDataResult> GetMealMacroData(int mealId);
    }
}
