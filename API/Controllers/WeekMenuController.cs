using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekMenuController : CRUDController<WeekMenu>
    {
        public WeekMenuController(IWeekMenuLogic logic) : base(logic)
        {
        }
    }
}
