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

        public Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId)
        {
            return (await _dbContext.GetProcedures().GetDayMenuMacroDataAsync(dayMenuId)).First();
        }
    }
}
