using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class IngredientLogic : CRUDLogic<Ingredient>, IIngredientLogic
    {
        private readonly IIngredientRepository _repository;
        public IngredientLogic(IIngredientRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IngredientDataView>> GetAllByRecipeId(int recipeId)
        {
            return await _repository.GetAllByRecipeId(recipeId);
        }
    }
}
