using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekMenuController : CRUDController<WeekMenu>
    {
        private readonly IWeekMenuLogic _logic;
        public WeekMenuController(IWeekMenuLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpPost("InitWeekMenu")]
        public WeekMenu InitWeekMenu(WeekMenu weekMenu)
        {
            return _logic.InitWeekMenu(weekMenu);
        }

        [HttpGet("GetWeekMenuDTO/{id}")]
        public Task<WeekMenuDTO> GetWeekMenuDTO(int id)
        {
            return _logic.GetWeekMenuDTO(id);
        }

        [HttpPost("CreateWeekMenuDTO")]
        public Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO)
        {
            return _logic.CreateWeekMenuDTO(weekMenuDTO);
        }

        [HttpGet("ReadAllByCustomerPreferences/{customerId}")]
        public Task<IEnumerable<WeekMenu>> ReadAllByCustomerPreferences(int customerId)
        {
            return _logic.ReadAllByCustomerPreferences(customerId);
        }
    }
}
