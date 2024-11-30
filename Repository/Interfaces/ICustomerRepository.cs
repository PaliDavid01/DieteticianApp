using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface ICustomerRepository : ICRUDRepository<Customer>
    {
        Task<ICollection<CustomerListView>> GetAllCustomerListViewAsync();
    }
}
