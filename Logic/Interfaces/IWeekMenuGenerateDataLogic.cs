using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IWeekMenuGenerateDataLogic : ICRUDLogic<WeekMenuGenerateDatum>
    {
        WeekMenuGenerateDatum GetByWeekMenuId(int weekMenuId);
    }
}
