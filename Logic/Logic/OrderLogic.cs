using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class OrderLogic : CRUDLogic<Order>, IOrderLogic
    {
        private readonly IOrderRepository repository;
        public OrderLogic(IOrderRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public Task InitializeOrders(int customerId)
        {
            return repository.InitializeOrders(customerId);
        }

        public async Task<IEnumerable<OrderListView>> ReadAllByCustomerId(int customerId)
        {
            return await repository.ReadAllByCustomerId(customerId);
        }
    }
}
