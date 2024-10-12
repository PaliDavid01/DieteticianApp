using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class WeekOrderLogic : CRUDLogic<WeekOrder>, IWeekOrderLogic
    {
        public WeekOrderLogic(IWeekOrderRepository repository) : base(repository)
        {
        }
    }
}
