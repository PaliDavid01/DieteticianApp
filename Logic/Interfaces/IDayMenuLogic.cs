using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IDayMenuLogic : ICRUDLogic<DayMenu>
    {
        Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId);
        Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId);
    }
}
