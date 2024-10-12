using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class DayMenuRepository : CRUDRepository<DayMenu>, IDayMenuRepository
    {
        public DayMenuRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
