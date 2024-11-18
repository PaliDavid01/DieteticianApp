using Models.DTOs;
using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IWeekMenuRepository : ICRUDRepository<WeekMenu>
    {
        WeekMenu InitWeekMenu(WeekMenu weekMenu);
        public Task<WeekMenuDTO> GetWeekMenuDTO(int id);
        public Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO);
    }
}
