using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class OrderWeekMenuRepository : CRUDRepository<OrderWeekMenu>, IOrderWeekMenuRepository
    {
        public OrderWeekMenuRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteByOrderId(int orderId)
        {
            var orderWeekMenu = await _dbContext.OrderWeekMenus.Where(owm => owm.OrderId == orderId).FirstOrDefaultAsync();
            _dbContext.OrderWeekMenus.Remove(orderWeekMenu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
