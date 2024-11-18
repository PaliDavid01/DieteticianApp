using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class WeekMenuGenerateDataRepository : CRUDRepository<WeekMenuGenerateDatum>, IWeekMenuGenerateDataRepository
    {
        public WeekMenuGenerateDataRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public WeekMenuGenerateDatum GetByWeekMenuId(int weekMenuId)
        {
            return _dbContext.WeekMenuGenerateData.Where(wmgd => wmgd.WeekMenuId == weekMenuId).FirstOrDefault();
        }
    }
}
