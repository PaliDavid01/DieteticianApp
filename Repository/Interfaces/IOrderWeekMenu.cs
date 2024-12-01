using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IOrderWeekMenuRepository : ICRUDRepository<OrderWeekMenu>
    {
        Task DeleteByOrderId(int orderId);
    }
}
