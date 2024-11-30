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
    public class CustomerController : CRUDController<Customer>
    {
        private ICustomerLogic _logic;
        public CustomerController(ICustomerLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllCustomerListView")]
        public async Task<ICollection<CustomerListView>> GetAllCustomerListView()
        {
            return await _logic.GetAllCustomerListViewAsync();
        }
    }
}
