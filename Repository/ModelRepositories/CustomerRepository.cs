using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class CustomerRepository : CRUDRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<ICollection<CustomerListView>> GetAllCustomerListViewAsync()
        {
            return await _dbContext.CustomerListViews.ToListAsync();
        }
    }
}
