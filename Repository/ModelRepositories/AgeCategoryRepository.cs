using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class AgeCategoryRepository : CRUDRepository<AgeCategory>, IAgeCategoryRepository
    {
        public AgeCategoryRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
