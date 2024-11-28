using Logic.Interfaces.GenericInterfaces;
using Models;
using Models.Models;
using static Logic.Logic.DayMenuLogic;

namespace Logic.Interfaces
{
    public interface IDayMenuLogic : ICRUDLogic<DayMenu>
    {
        Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId);
        Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId);
        Task<Dictionary<MealType, ICollection<MealRecipeDTO>>> GenerateDayMenu(int weekMenuId);
        Task SaveGeneratedDaymenu(int dayMenuId, Dictionary<MealType, MealRecipe> dayMenu);
    }
}
