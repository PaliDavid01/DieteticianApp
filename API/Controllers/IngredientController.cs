using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : CRUDController<Ingredient>
    {
        private readonly IIngredientLogic _logic;
        public IngredientController(IIngredientLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpGet("GetAllByRecipeId/{recipeId}")]
        public async Task<IEnumerable<IngredientDataView>> GetAllByRecipeId(int recipeId)
        {
            return await _logic.GetAllByRecipeId(recipeId);
        }
    }
}
