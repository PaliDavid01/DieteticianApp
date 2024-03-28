using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.GenericRepository;
using Repository.Interfaces;

namespace Repository.ModelRepositories
{
    public class StockRepository : CRUDRepository<Stock>, IStockRepository
    {
        public StockRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
