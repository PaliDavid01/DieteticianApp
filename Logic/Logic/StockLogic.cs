using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;
namespace Logic.Logic
{
    public class StockLogic : CRUDLogic<Stock>, IStockLogic
    {
        public StockLogic(IStockRepository repository) : base(repository)
        {
        }
    }
}
