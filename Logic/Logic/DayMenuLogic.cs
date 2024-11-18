using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class DayMenuLogic : CRUDLogic<DayMenu>, IDayMenuLogic
    {
        private readonly IDayMenuRepository _repository;
        public DayMenuLogic(IDayMenuRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId)
        {
            return _repository.GetDayMenuByWeekMenuId(weekMenuId);
        }

        public Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId)
        {
            return _repository.GetGetDayMenuMacroData(dayMenuId);
        }
    }
}
