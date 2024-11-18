using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "IT,Supervisor,Dietitian")]
    public class WeekMenuGenerateDataController : CRUDController<WeekMenuGenerateDatum>
    {
        private IWeekMenuGenerateDataLogic _logic;
        public WeekMenuGenerateDataController(IWeekMenuGenerateDataLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("GetWeekMenuGenerateDataByWeekMenuId/{weekMenuId}")]
        public WeekMenuGenerateDatum GetByWeekMenuId(int weekMenuId)
        {
            return _logic.GetByWeekMenuId(weekMenuId);
        }
    }
}

