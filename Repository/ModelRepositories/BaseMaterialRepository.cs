using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

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
