using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class AllergenRepository : CRUDRepository<Allergen>, IAllergenRepository
    {
        public AllergenRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
