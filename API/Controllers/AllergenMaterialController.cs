using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
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
        [HttpPost("CreateAllergenMaterials")]
        public Task CreateAllergenMaterials(List<AllergenMaterial> allergenMaterials)
        {
            return _logic.CreateAllergenMaterials(allergenMaterials);
        }
        [HttpPut("UpdateAllergenMaterials")]
        public Task UpdateAllergenMaterials(UpdateAllergenMaterialsDTO updateAllergenMaterialsDTO)
        {
            return _logic.UpdateAllergenMaterials(updateAllergenMaterialsDTO);
        }

    }
}
