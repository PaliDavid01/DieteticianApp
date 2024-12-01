using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class OrderRepository : CRUDRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task InitializeOrders(int customerId)
        {
            var nowdate = DateTime.Now;
            // next week monday
            var weekStart = nowdate.AddDays(((int)DayOfWeek.Monday - (int)nowdate.DayOfWeek + 7) % 7);
            // next week sunday
            var weekEnd = weekStart.AddDays(6);
            try
            {
                await _dbContext.Database.BeginTransactionAsync();
                for (var i = 0; i < 50; i++)
                {
                    var order = new Order
                    {
                        CustomerId = customerId,
                        OrderStartDate = weekStart,
                        OrderEndDate = weekStart.AddDays(6)
                    };
                    weekStart = weekStart.AddDays(7);
                    _dbContext.Orders.Add(order);
                }
                await _dbContext.SaveChangesAsync();
                await _dbContext.Database.CommitTransactionAsync();
            }
            catch (Exception e)
            {
                await _dbContext.Database.RollbackTransactionAsync();
                throw new Exception(e.Message);
            }
            finally
            {
                _dbContext.Dispose();
            }

        }

        public async Task<IEnumerable<OrderListView>> ReadAllByCustomerId(int customerId)
        {
            return await _dbContext.OrderListViews.Where(o => o.CustomerId == customerId).ToListAsync();
        }

    }
}
