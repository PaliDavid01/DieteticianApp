using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class OrderWeekMenuLogic : CRUDLogic<OrderWeekMenu>, IOrderWeekMenuLogic
    {
        private readonly IOrderWeekMenuRepository _repository;
        public OrderWeekMenuLogic(IOrderWeekMenuRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task DeleteByOrderId(int orderId)
        {
            return _repository.DeleteByOrderId(orderId);
        }
    }
}
