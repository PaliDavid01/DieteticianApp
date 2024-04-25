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
    }
}
