using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class WeekOrderRepository : CRUDRepository<WeekOrder>, IWeekOrderRepository
    {
        public WeekOrderRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
