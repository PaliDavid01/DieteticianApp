using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IWeekMenuGenerateDataRepository : ICRUDRepository<WeekMenuGenerateDatum>
    {
        WeekMenuGenerateDatum GetByWeekMenuId(int weekMenuId);
    }
}
