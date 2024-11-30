using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AllergenCustomerLogic : CRUDLogic<AllergenCustomer>, IAllergenCustomerLogic
    {
        private readonly IAllergenCustomerRepository _repository;
        public AllergenCustomerLogic(IAllergenCustomerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<int>> GetAllergensByCustomerId(int Id)
        {
            return await _repository.GetAllergensByCustomerId(Id);
        }

        public async Task UpdateAllergenMaterials(UpdateAllergenCustomersDTO updateAllergenCustomersDTO)
        {
            var allergenCustomers = updateAllergenCustomersDTO.AllergenCustomers;

            var allergenustomersAlreadyHas = await _repository.FindAsync(t => t.CustomerId == updateAllergenCustomersDTO.CustomerId);

            foreach (var allergenCustomer in allergenCustomers)
            {
                if (!(allergenustomersAlreadyHas.Any(x => x.AllergenId == allergenCustomer.AllergenId)))
                {
                    await _repository.CreateAsync(allergenCustomer);
                }
                else if (allergenustomersAlreadyHas.Any(x => x.AllergenId == allergenCustomer.AllergenId))
                {

                }
            }
            var allergenCustomersToDelete = allergenustomersAlreadyHas.Where(x => !allergenCustomers.Any(y => y.AllergenId == x.AllergenId));
            foreach (var allergenMaterial in allergenCustomersToDelete)
            {
                await _repository.DeleteAsync(allergenMaterial);
            }
        }

    }
}
