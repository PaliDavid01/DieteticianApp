using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class IngredientRepository : CRUDRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<IngredientDataView>> GetAllByRecipeId(int recipeId)
        {

            return await _dbContext.IngredientDataViews.Where(t => t.RecipeId == recipeId).ToListAsync();
        }

    }
}
