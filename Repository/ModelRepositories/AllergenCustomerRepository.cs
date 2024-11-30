using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class AllergenCustomerRepository : CRUDRepository<AllergenCustomer>, IAllergenCustomerRepository
    {
        public AllergenCustomerRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<int>> GetAllergensByCustomerId(int Id)
        {
            return await _dbContext.AllergenCustomers.Where(x => x.CustomerId == Id).Select(x => x.AllergenId).ToListAsync();
        }
    }
}
