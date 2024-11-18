using Logic.Interfaces.GenericInterfaces;
using Models.DTOs;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IWeekMenuGenerateDataAllergenLogic : ICRUDLogic<WeekMenuGenerateDataAllergen>
    {
        IQueryable<WeekMenuGenerateDataAllergen> GetByWeekMenuGenerateDataId(int weekMenuGenerateDataId);
        Task UpdateAllergenWeekMenuGenerateDatas(UpdateAllergenWeekMenuDataDTO updateAllergenMaterialsDTO);
    }
}
