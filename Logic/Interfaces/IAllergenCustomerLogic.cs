using Logic.Interfaces.GenericInterfaces;
using Models.DTOs;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IAllergenCustomerLogic : ICRUDLogic<AllergenCustomer>
    {
        Task UpdateAllergenMaterials(UpdateAllergenCustomersDTO updateAllergenCustomersDTO);
        Task<IEnumerable<int>> GetAllergensByCustomerId(int Id);
    }
}
