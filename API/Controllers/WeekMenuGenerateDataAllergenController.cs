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
    public class WeekMenuGenerateDataAllergenController : CRUDController<WeekMenuGenerateDataAllergen>
    {
        private IWeekMenuGenerateDataAllergenLogic _logic;
        public WeekMenuGenerateDataAllergenController(IWeekMenuGenerateDataAllergenLogic logic) : base(logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("WeekMenuGenerateDataAllergenId/{weekMenuGenerateDataId}")]
        public IQueryable<WeekMenuGenerateDataAllergen> GetByWeekMenuGenerateDataId(int weekMenuGenerateDataId)
        {
            return _logic.GetByWeekMenuGenerateDataId(weekMenuGenerateDataId);
        }

        [HttpPost]
        [Route("UpdateAllergenWeekMenuGenerateDatas")]
        public async Task UpdateAllergenWeekMenuGenerateDatas(UpdateAllergenWeekMenuDataDTO updateAllergenMaterialsDTO)
        {
            await _logic.UpdateAllergenWeekMenuGenerateDatas(updateAllergenMaterialsDTO);
        }
    }
}
