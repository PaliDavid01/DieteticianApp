using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IWeekMenuGenerateDataAllergenRepository : ICRUDRepository<WeekMenuGenerateDataAllergen>
    {
        IQueryable<WeekMenuGenerateDataAllergen> GetByWeekMenuGenerateDataId(int weekMenuGenerateDataId);
    }
}
