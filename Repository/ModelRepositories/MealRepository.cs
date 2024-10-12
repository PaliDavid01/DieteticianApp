using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class MealRepository : CRUDRepository<Meal>, IMealRepository
    {
        public MealRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }
    }
}
