using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface ICustomerLogic : ICRUDLogic<Customer>
    {
        Task<ICollection<CustomerListView>> GetAllCustomerListViewAsync();
    }
}
