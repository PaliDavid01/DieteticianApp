using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class AllergenMaterialRepository : CRUDRepository<AllergenMaterial>, IAllergenMaterialRepository
    {
        public AllergenMaterialRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
