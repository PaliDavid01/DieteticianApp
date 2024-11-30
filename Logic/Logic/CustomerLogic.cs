using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class CustomerLogic : CRUDLogic<Customer>, ICustomerLogic
    {
        private ICustomerRepository _repository;
        public CustomerLogic(ICustomerRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<CustomerListView>> GetAllCustomerListViewAsync()
        {
            return await _repository.GetAllCustomerListViewAsync();
        }
    }
}
