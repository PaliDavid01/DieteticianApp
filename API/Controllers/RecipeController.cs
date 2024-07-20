using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : CRUDController<Recipe>
    {
        private readonly IRecipeLogic _logic;
        public RecipeController(IRecipeLogic logic) : base(logic)
        {
            _logic = logic;
        }
        [HttpPut("RecalculateMacros/{recipeId}")]
        public async Task RecalculateMacros(int recipeId)
        {
            await _logic.RecalculateMacros(recipeId);
        }
    }
}
