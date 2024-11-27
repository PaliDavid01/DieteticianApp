using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using static Logic.Logic.DayMenuLogic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "IT,Supervisor,Dietitian")]
    public class DayMenuController : CRUDController<DayMenu>
    {
        private readonly IDayMenuLogic _logic;
        public DayMenuController(IDayMenuLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpGet("GetDayMenuByWeekMenuId/{weekMenuId}")]
        public Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId)
        {
            return _logic.GetDayMenuByWeekMenuId(weekMenuId);
        }

        [HttpGet("GetDayMenuMacroData/{dayMenuId}")]
        public Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId)
        {
            return _logic.GetGetDayMenuMacroData(dayMenuId);
        }

        [HttpPost("GenerateDayMenu/{weekMenuId}/{dayMenuId}")]
        public async Task<Dictionary<MealType, ICollection<MealRecipeDTO>>> GenerateDayMenu(int weekMenuId, int dayMenuId)
        {
            return await _logic.GenerateDayMenu(weekMenuId, dayMenuId);
        }
    }
}
