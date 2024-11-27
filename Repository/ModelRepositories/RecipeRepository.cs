using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<RecipeGenerateDataView>> ReadAllRecipeGenerateDataViewAsync()
        {
            return await _dbContext.RecipeGenerateDataViews.ToListAsync();
        }
    }
}
