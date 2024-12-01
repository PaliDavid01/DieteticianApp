using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IOrderLogic : ICRUDLogic<Order>
    {
        Task<IEnumerable<OrderListView>> ReadAllByCustomerId(int customerId);
        Task InitializeOrders(int customerId);
    }
}
