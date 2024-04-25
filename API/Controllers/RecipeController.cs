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
        public RecipeController(IRecipeLogic logic) : base(logic)
        {

        }
    }
}
