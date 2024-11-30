using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "IT,Supervisor,Dietitian")]
    public class AllergenCustomerController : CRUDController<AllergenCustomer>
    {
        private readonly IAllergenCustomerLogic _logic;
        public AllergenCustomerController(IAllergenCustomerLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllergensByCustomerId/{Id}")]
        public async Task<IEnumerable<int>> GetAllergensByCustomerId(int Id)
        {
            return await _logic.GetAllergensByCustomerId(Id);
        }

        [HttpPost("UpdateAllergenMaterials")]
        public async Task UpdateAllergenMaterials(UpdateAllergenCustomersDTO updateAllergenCustomersDTO)
        {
            await _logic.UpdateAllergenMaterials(updateAllergenCustomersDTO);
        }

    }
}
