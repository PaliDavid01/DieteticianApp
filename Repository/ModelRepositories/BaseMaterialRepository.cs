using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class BaseMaterialRepository : CRUDRepository<BaseMaterial>, IBaseMaterialRepository
    {
        DataBaseContext _dbContext;
        public BaseMaterialRepository(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseMaterial> GetAllExtended()
        {
            return null;
        }
    }
}
