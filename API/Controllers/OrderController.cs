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
    public class OrderController : CRUDController<Order>
    {
        private readonly IOrderLogic logic;
        public OrderController(IOrderLogic logic) : base(logic)
        {
            this.logic = logic;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IEnumerable<OrderListView>> ReadAllByCustomerId(int customerId)
        {
            return await logic.ReadAllByCustomerId(customerId);
        }

        [HttpPost("initialize/{customerId}")]
        public async Task InitializeOrders(int customerId)
        {
            await logic.InitializeOrders(customerId);
        }
    }
}
