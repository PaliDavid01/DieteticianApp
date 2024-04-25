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
        public IngredientController(IIngredientLogic logic) : base(logic)
        {
        }
    }
}
