using Logic.Interfaces.GenericInterfaces;
using Models.DTOs;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IWeekMenuLogic : ICRUDLogic<WeekMenu>
    {
        WeekMenu InitWeekMenu(WeekMenu weekMenu);
        public Task<WeekMenuDTO> GetWeekMenuDTO(int id);
        public Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO);
        Task<IEnumerable<WeekMenu>> ReadAllByCustomerPreferences(int customerId);
    }
}
