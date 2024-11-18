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
    public class MealController : CRUDController<Meal>
    {
        private readonly IMealLogic _logic;
        public MealController(IMealLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpPost]
        public int CreateWithReturnId(Meal meal)
        {
            return _logic.CreateWithReturnId(meal);
        }

        [HttpGet("GetMealMacroData/{mealId}")]
        public async Task<GetMealMacroDataResult> GetMealMacroData(int mealId)
        {
            return await _logic.GetMealMacroData(mealId);
        }
    }
}
