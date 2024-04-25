using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class RecipeCategoryLogic : CRUDLogic<RecipeCategory>, IRecipeCategoryLogic
    {
        public RecipeCategoryLogic(IRecipeCategoryRepository repository) : base(repository)
        {
        }
    }
}
