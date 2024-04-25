using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class StockRepository : CRUDRepository<Stock>, IStockRepository
    {
        public StockRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
