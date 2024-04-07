using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenMaterialController : CRUDController<AllergenMaterial>
    {
        private readonly IAllergenMaterialLogic _logic;
        public AllergenMaterialController(IAllergenMaterialLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpGet("GetAllergensByMaterialId/{Id}")]
        public Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id)
        {
            return _logic.GetAllergensByMaterialId(Id);
        }

    }
}
