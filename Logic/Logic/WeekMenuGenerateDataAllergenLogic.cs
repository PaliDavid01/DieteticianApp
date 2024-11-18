using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class WeekMenuGenerateDataAllergenLogic : CRUDLogic<WeekMenuGenerateDataAllergen>, IWeekMenuGenerateDataAllergenLogic
    {
        private IWeekMenuGenerateDataAllergenRepository _repository;
        public WeekMenuGenerateDataAllergenLogic(IWeekMenuGenerateDataAllergenRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IQueryable<WeekMenuGenerateDataAllergen> GetByWeekMenuGenerateDataId(int weekMenuGenerateDataId)
        {
            return _repository.GetByWeekMenuGenerateDataId(weekMenuGenerateDataId);
        }
        public async Task UpdateAllergenWeekMenuGenerateDatas(UpdateAllergenWeekMenuDataDTO updateAllergenMaterialsDTO)
        {
            var allergenWeekMenuGenerateDatas = updateAllergenMaterialsDTO.AllergenWeekMenuDatas;

            var allergenAlreadyHas = await _repository.FindAsync(t => t.WeekMenuGenerateDataId == updateAllergenMaterialsDTO.WeekMWeekMenuGenerateDataId);

            foreach (var allergenMaterial in allergenWeekMenuGenerateDatas)
            {
                if (!(allergenAlreadyHas.Any(x => x.AllergenId == allergenMaterial.AllergenId)))
                {
                    await _repository.CreateAsync(allergenMaterial);
                }
                else if (allergenAlreadyHas.Any(x => x.AllergenId == allergenMaterial.AllergenId))
                {

                }
            }
            var allergenMaterialsToDelete = allergenAlreadyHas.Where(x => !allergenWeekMenuGenerateDatas.Any(y => y.AllergenId == x.AllergenId));
            foreach (var allergenMaterial in allergenMaterialsToDelete)
            {
                await _repository.DeleteAsync(allergenMaterial);
            }
        }
    }
}
