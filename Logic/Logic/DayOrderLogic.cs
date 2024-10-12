using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class DayOrderLogic : CRUDLogic<DayOrder>, IDayOrderLogic
    {
        public DayOrderLogic(IDayOrderRepository repository) : base(repository)
        {
        }
    }
}
