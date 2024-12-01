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
    public class OrderWeekMenuController : CRUDController<OrderWeekMenu>
    {
        private readonly IOrderWeekMenuLogic logic;
        public OrderWeekMenuController(IOrderWeekMenuLogic logic) : base(logic)
        {
            this.logic = logic;
        }
        [HttpDelete("delete/{orderId}")]
        public async Task DeleteByOrderId(int orderId)
        {
            await logic.DeleteByOrderId(orderId);
        }
    }


}
