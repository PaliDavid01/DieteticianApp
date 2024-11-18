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
    public class MealRecipeController : CRUDController<MealRecipe>
    {
        private readonly IMealRecipeLogic _logic;
        public MealRecipeController(IMealRecipeLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public async Task<IEnumerable<GetMealRecipe>> GetAllDTO(int mealId)
        {
            return await _logic.GetAllDTO(mealId);
        }
    }
}
