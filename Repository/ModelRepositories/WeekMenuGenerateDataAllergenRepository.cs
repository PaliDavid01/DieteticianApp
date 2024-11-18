using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class WeekMenuGenerateDataAllergenRepository : CRUDRepository<WeekMenuGenerateDataAllergen>, IWeekMenuGenerateDataAllergenRepository
    {
        public WeekMenuGenerateDataAllergenRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<WeekMenuGenerateDataAllergen> GetByWeekMenuGenerateDataId(int weekMenuGenerateDataId)
        {
            return _dbContext.WeekMenuGenerateDataAllergens.Where(wmgda => wmgda.WeekMenuGenerateDataId == weekMenuGenerateDataId);
        }
    }
}
