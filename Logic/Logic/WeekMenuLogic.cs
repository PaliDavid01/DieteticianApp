using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class WeekMenuLogic : CRUDLogic<WeekMenu>, IWeekMenuLogic
    {
        private readonly IWeekMenuRepository _repository;
        public WeekMenuLogic(IWeekMenuRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public WeekMenu InitWeekMenu(WeekMenu weekMenu)
        {
            return _repository.InitWeekMenu(weekMenu);
        }
        public Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO)
        {
            return _repository.CreateWeekMenuDTO(weekMenuDTO);
        }

        public Task<WeekMenuDTO> GetWeekMenuDTO(int id)
        {
            return _repository.GetWeekMenuDTO(id);
        }
    }
}
