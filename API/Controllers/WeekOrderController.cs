using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekOrderController : CRUDController<WeekOrder>
    {
        public WeekOrderController(IWeekOrderLogic logic) : base(logic)
        {
        }
    }
}
