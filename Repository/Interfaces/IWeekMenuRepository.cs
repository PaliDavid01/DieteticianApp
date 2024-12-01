using Models.DTOs;
using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IWeekMenuRepository : ICRUDRepository<WeekMenu>
    {
        WeekMenu InitWeekMenu(WeekMenu weekMenu);
        Task<WeekMenuDTO> GetWeekMenuDTO(int id);
        Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO);

        Task<IEnumerable<WeekMenu>> ReadAllByCustomerPreferences(int customerId);
    }
}
