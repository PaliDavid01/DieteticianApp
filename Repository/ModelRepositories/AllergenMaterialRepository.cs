using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class AllergenMaterialRepository : CRUDRepository<AllergenMaterial>, IAllergenMaterialRepository
    {
        public AllergenMaterialRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<AllergenMaterialView>> GetAllergensByMaterialId(int Id)
        {
            return await _dbContext.AllergenMaterialViews.Where(t => t.MaterialId == Id).ToListAsync();
        }
    }
}
