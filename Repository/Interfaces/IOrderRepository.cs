using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IOrderRepository : ICRUDRepository<Order>
    {
        Task<IEnumerable<OrderListView>> ReadAllByCustomerId(int customerId);
        Task InitializeOrders(int customerId);
    }
}
