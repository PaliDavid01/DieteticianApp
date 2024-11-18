using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class WeekMenuGenerateDataLogic : CRUDLogic<WeekMenuGenerateDatum>, IWeekMenuGenerateDataLogic
    {
        private IWeekMenuGenerateDataRepository _repository;
        public WeekMenuGenerateDataLogic(IWeekMenuGenerateDataRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public WeekMenuGenerateDatum GetByWeekMenuId(int weekMenuId)
        {
            return _repository.GetByWeekMenuId(weekMenuId);
        }
    }
}
