using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class WeekMenuRepository : CRUDRepository<WeekMenu>, IWeekMenuRepository
    {
        public WeekMenuRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }
    }
}
