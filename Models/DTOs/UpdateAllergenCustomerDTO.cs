using Models.Models;

namespace Models.DTOs
{
    public class UpdateAllergenCustomersDTO
    {
        public int CustomerId { get; set; }
        public List<AllergenCustomer> AllergenCustomers { get; set; }
    }
}
