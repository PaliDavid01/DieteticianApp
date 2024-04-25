using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class RecipeRepository : CRUDRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
