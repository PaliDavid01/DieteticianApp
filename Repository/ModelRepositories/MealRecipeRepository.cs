using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class MealRecipeRepository : CRUDRepository<MealRecipe>, IMealRecipeRepository
    {
        public MealRecipeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
