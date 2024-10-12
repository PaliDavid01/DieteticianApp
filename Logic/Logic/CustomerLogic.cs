using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class CustomerLogic : CRUDLogic<Customer>, ICustomerLogic
    {
        public CustomerLogic(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
