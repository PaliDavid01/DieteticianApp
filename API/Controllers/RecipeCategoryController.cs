using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeCategoryController : CRUDController<RecipeCategory>
    {
        public RecipeCategoryController(IRecipeCategoryLogic logic) : base(logic)
        {

        }
    }
}
