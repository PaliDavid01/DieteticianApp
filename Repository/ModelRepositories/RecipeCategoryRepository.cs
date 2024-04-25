using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class RecipeCategoryRepository : CRUDRepository<RecipeCategory>, IRecipeCategoryRepository
    {
        public RecipeCategoryRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
