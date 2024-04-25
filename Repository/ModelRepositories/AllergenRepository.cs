using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class AllergenRepository : CRUDRepository<Allergen>, IAllergenRepository
    {
        public AllergenRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
