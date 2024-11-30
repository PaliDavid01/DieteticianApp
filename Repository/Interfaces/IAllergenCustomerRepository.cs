using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IAllergenCustomerRepository : ICRUDRepository<AllergenCustomer>
    {
        Task<IEnumerable<int>> GetAllergensByCustomerId(int Id);
    }
}
