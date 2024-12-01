using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IOrderWeekMenuLogic : ICRUDLogic<OrderWeekMenu>
    {
        Task DeleteByOrderId(int orderId);
    }
}
