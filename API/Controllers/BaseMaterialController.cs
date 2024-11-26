using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseMaterialController : CRUDController<BaseMaterial>
    {
        private readonly IBaseMaterialLogic _logic;
        public BaseMaterialController(IBaseMaterialLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpGet("LoadFromExcel")]
        public IActionResult LoadFromExcel()
        {
            _logic.LoadFromExcel();
            return Ok();
        }
        [HttpGet("GetBaseMaterialsExtended")]
        public Task<IEnumerable<BaseMaterial>> GetBaseMaterialsExtended()
        {
            return _logic.GetBaseMaterialsExtended();
        }
        [HttpDelete("DeleteWithAlllergenMaterials")]
        public async Task DeleteWithAlllergenMaterials(BaseMaterial entity)
        {
            await _logic.DeleteWithAlllergenMaterials(entity);
        }

        [HttpGet("Load")]
        public void Load()
        {
            _logic.LoadData();
        }
    }
}
